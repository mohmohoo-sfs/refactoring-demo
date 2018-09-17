﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace api.Authentication
{
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public string Realm { get; set; }
    }

    public class ApiAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private static readonly Dictionary<string, string> _AllowedApps = new Dictionary<string, string>
        {
            { "4d53bce03ec34c0a911182d4c228ee6c", "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=" }
        };
        private const string _AUTHENTICATION_SCHEME = "amx";
        private const ulong _REQUEST_MAX_AGE_IN_SECONDS = 300;
        private readonly IMemoryCache _cache;
        private static readonly DateTime _1970 = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);

        public ApiAuthenticationHandler(
            IMemoryCache memoryCache,
            IOptionsMonitor<ApiKeyAuthenticationOptions> options, 
            ILoggerFactory loggerFactory, 
            UrlEncoder encoder,
            ISystemClock systemClock)
            : base(options, loggerFactory, encoder, systemClock)
        {
            _cache = memoryCache;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authorisation = Context.Request.Headers["Authorization"][0];

            if (authorisation.StartsWith(_AUTHENTICATION_SCHEME))
            {
                var autherizationHeaderArray = GetAuthHeaderValues(authorisation);

                if (autherizationHeaderArray != null)
                {
                    var appId = autherizationHeaderArray[0];
                    var incomingBase64Signature = autherizationHeaderArray[1];
                    var nonce = autherizationHeaderArray[2];
                    var requestTimeStamp = autherizationHeaderArray[3];

                    var request = Context.Request;
                    var isValid = IsValidRequest(request, appId, incomingBase64Signature, nonce, requestTimeStamp);

                    if (isValid)
                    {
                        var _identity = new ClaimsIdentity("api");
                        var _ticket = new AuthenticationTicket(new ClaimsPrincipal(_identity), null, "api");
                        return Task.FromResult(AuthenticateResult.Success(_ticket));
                    }

                    return Task.FromResult(AuthenticateResult.Fail("Incorrect Auth"));
                }
            }

            return Task.FromResult(AuthenticateResult.Fail("Incorrect Auth"));
        }

        private static string[] GetAuthHeaderValues(string authorisationHeader)
        {
            var credArray = authorisationHeader.Split(' ')[1].Split(':');
            return credArray.Length == 4 ? credArray : null;
        }

        private static byte[] ComputeHash(Stream body)
        {
            using (var md5 = MD5.Create())
            {
                var content = GetBytes(body);

                byte[] hash = content.Length != 0
                    ? md5.ComputeHash(content)
                    : null;
                return hash;
            }
        }

        private bool IsReplayRequest(string nonce, string requestTimeStamp)
        {
            if (_cache.TryGetValue(nonce, out object _)) return true;

            TimeSpan currentTs = DateTime.UtcNow - _1970;
            var serverTotalSeconds = Convert.ToUInt64(currentTs.TotalSeconds);
            var requestTotalSeconds = Convert.ToUInt64(requestTimeStamp);

            if (serverTotalSeconds - requestTotalSeconds > _REQUEST_MAX_AGE_IN_SECONDS) return true;

            _cache.Set(nonce, requestTimeStamp, DateTimeOffset.UtcNow.AddSeconds(_REQUEST_MAX_AGE_IN_SECONDS));

            return false;
        }

        private static byte[] GetBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        private bool IsValidRequest(HttpRequest request, string appId, string incomingBase64Signature, string nonce,
            string requestTimeStamp)
        {
            string requestContentBase64String = "";
            string requestUri =
                HttpUtility.UrlEncode(request.Scheme + "://" + request.Host +
                                      request.Path); 
            string requestHttpMethod = request.Method;
            
            if (!_AllowedApps.ContainsKey(appId)) return false;

            var sharedKey = _AllowedApps[appId];

            if (IsReplayRequest(nonce, requestTimeStamp)) return false;

            byte[] hash = ComputeHash(request.Body);

            if (hash != null)
            {
                requestContentBase64String = Convert.ToBase64String(hash);
            }

            var data = $"{appId}{requestHttpMethod}{requestUri}{requestTimeStamp}{nonce}{requestContentBase64String}";

            var secretKeyBytes = Convert.FromBase64String(sharedKey);

            byte[] signature = Encoding.UTF8.GetBytes(data);

            using (var hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                return incomingBase64Signature.Equals(Convert.ToBase64String(signatureBytes), StringComparison.Ordinal);
            }
        }
    }
}
