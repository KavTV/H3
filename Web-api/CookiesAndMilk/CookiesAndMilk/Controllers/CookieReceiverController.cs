using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookiesAndMilk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieReceiverController : ControllerBase
    {
        //OPGAVE 1

        [HttpGet]
        public string Get()
        {
            //No problem finding the cookie made by other controllers
            string foundShake = Request.Cookies["trytogetthis"];
            if (foundShake == null)
                foundShake = "unknown";
            return foundShake;
        }

    }
}
