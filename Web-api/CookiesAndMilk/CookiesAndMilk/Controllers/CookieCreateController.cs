using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookiesAndMilk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieCreateController : ControllerBase
    {
        //OPGAVE 1

        [HttpGet]
        public string Get([FromQuery] string someinformation)
        {
            //this can be seen by other controllers
            Response.Cookies.Append("trytogetthis", someinformation);
            return "Cookie created";
        }
    }
}
