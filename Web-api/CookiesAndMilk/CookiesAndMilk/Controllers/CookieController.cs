using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookiesAndMilk.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        //OPGAVE 1

        [HttpGet]
        public string Get(string favshake)
        {
            if (favshake != null)
            {
                //Create options for cookie
                CookieOptions cookieOptions = new CookieOptions();
                //Set time until cookie expires
                cookieOptions.MaxAge = TimeSpan.FromMinutes(5);
                //Give the cookie to client
                Response.Cookies.Append("favshake", favshake, cookieOptions);
                return favshake;
            }
            return "No input";
        }

        [HttpGet]
        [Route("[action]")]
        public string GetFromCookie()
        {
            //Find the shake cookie
            string foundShake = Request.Cookies["favshake"];
            //If it is empty tell user
            if (foundShake == null)
                foundShake = "unknown";
            return foundShake;
        }

        //Since i got swagger i can easily request delete
        [HttpDelete]
        public string Delete()
        {
            CookieOptions co = new CookieOptions();
            //Making the age 0 deletes the cookie
            co.MaxAge = TimeSpan.FromSeconds(0);
            Response.Cookies.Append("favshake", "", co);

            return "Cookie deleted";
        }
    }
}
