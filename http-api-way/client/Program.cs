using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace client
{
    //http://rredcat.blogspot.com/2017/12/secure-aspnet-core-web-api-using-api.html
    //http://bitoftech.net/2014/12/15/secure-asp-net-web-api-using-api-key-authentication-hmac-authentication/

    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Calling the back-end API");

            var customDelegatingHandler = new CustomDelegatingHandler();
            var client = new HttpClient(customDelegatingHandler);
            var response = await client.GetAsync("https://localhost:44307/api/secured");

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
                Console.WriteLine($"HTTP Status: {response.StatusCode}, Reason {response.ReasonPhrase}. Press ENTER to exit");
            }
            else
            {
                Console.WriteLine($"Failed to call the API. HTTP Status: {response.StatusCode}, Reason {response.ReasonPhrase}");
            }

            Console.ReadLine();
        }

        public class CustomDelegatingHandler : DelegatingHandler
        {
            //Obtained from the server earlier, APIKey MUST be stored securly and in App.Config
            private string APPId = "4d53bce03ec34c0a911182d4c228ee6c";
            private string APIKey = "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=";

            public CustomDelegatingHandler()
                : base()
            {
                InnerHandler = new HttpClientHandler();

            }

            protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var requestContentBase64String = string.Empty;
                var requestUri = System.Web.HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower());
                var requestHttpMethod = request.Method.Method;

                //Calculate UNIX time
                var epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
                var timeSpan = DateTime.UtcNow - epochStart;
                var requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

                //create random nonce for each request
                var nonce = Guid.NewGuid().ToString("N");

                //Checking if the request contains body, usually will be null wiht HTTP GET and DELETE
                if (request.Content != null)
                {
                    var content = await request.Content.ReadAsByteArrayAsync();
                    MD5 md5 = MD5.Create();
                    //Hashing the request body, any change in request body will result in different hash, we'll incure message integrity
                    var requestContentHash = md5.ComputeHash(content);
                    requestContentBase64String = Convert.ToBase64String(requestContentHash);
                }

                //Creating the raw signature string
                var signatureRawData = string.Format($"{APPId}{requestHttpMethod}{requestUri}{requestTimeStamp}{nonce}{requestContentBase64String}");

                var secretKeyByteArray = Convert.FromBase64String(APIKey);

                var signature = Encoding.UTF8.GetBytes(signatureRawData);

                using (var hmac = new HMACSHA256(secretKeyByteArray))
                {
                    var signatureBytes = hmac.ComputeHash(signature);
                    var requestSignatureBase64String = Convert.ToBase64String(signatureBytes);
                    //Setting the values in the Authorization header using custom scheme (amx)
                    request.Headers.Authorization = new AuthenticationHeaderValue("amx", $"{APPId}:{requestSignatureBase64String}:{nonce}:{requestTimeStamp}");
                }

                return await base.SendAsync(request, cancellationToken);

            }
        }
    }
}
