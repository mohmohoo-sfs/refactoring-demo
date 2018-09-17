using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize(AuthenticationSchemes = "api")]
    [Route("api/secured")]
    public class SecuredController : Controller
    {
        [HttpGet]
        public void Get()
        {
            Response.WriteAsync("Access granted");
        }
    }
}
