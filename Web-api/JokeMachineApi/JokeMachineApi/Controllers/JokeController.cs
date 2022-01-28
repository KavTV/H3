using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JokeMachineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        //REMEMBER TO USE SWAGGER FOR EASY TEST OF API: https://localhost:7134/swagger/index.html
        //AZURE LINK: https://jokemachineapi20220127153417.azurewebsites.net/api/Jokes

        // GET: api/<JokeController>
        [HttpGet]
        //[Authorize] Can use authorize if we want this method to only be accesed by people with a jwt token
        public IActionResult Get()
        {
            //Get the language of the request
            CultureInfo acceptLang = JokeProvider.GetLanguage(HttpContext.Request.Headers.AcceptLanguage);

            JokeCategory favCategory = JokeCategory.Any;

            //Make sure that we got a favCategory cookie, if not it is considered all categories
            if (Request.Cookies["favCategory"] != null)
            {
                //Get the favorite category
                favCategory = JokeProvider.GetCategory(Request.Cookies["favCategory"]);
            }

            List<JokeCategory> allowedCategories = HttpContext.Session.GetObjectFromJson<List<JokeCategory>>("AllowedCategories");

            //If we dont get any allowedCategories then we will only allow dad jokes, since they are bad anyways
            if (allowedCategories == null)
            {
                allowedCategories = new List<JokeCategory>
                {
                    JokeCategory.Dad
                };
            }

            //First we try to find the used jokes in the session, this could be null
            List<Joke> usedJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("Jokes");

            //If we already have some used jokes, then we will update the list
            if (usedJokes != null)
            {
                Joke randomJoke = null;

                if (favCategory != JokeCategory.Any && allowedCategories.Contains(favCategory))
                {
                    //Lets get a random joke that has filtered out all the used ones from a specific category
                    randomJoke = JokeProvider.GetRandomJokeFromCategory(usedJokes, acceptLang, favCategory);
                }
                else
                {
                    //Lets get a random joke that has filtered out all the used ones
                    randomJoke = JokeProvider.GetRandomJoke(usedJokes, acceptLang, allowedCategories);
                }

                //If we get a null value we dont have any new jokes left
                if (randomJoke == null)
                {
                    return StatusCode(404, "No more jokes");
                }

                usedJokes.Add(randomJoke);

                HttpContext.Session.SetObjectAsJson("Jokes", usedJokes);

                return StatusCode(200, randomJoke.JokeMessage);
            }
            //If not, we will create a new list and save it to the session
            else
            {
                //Make a new list with usedjokes
                List<Joke> jokes = new List<Joke>();

                //If we give an empty list, it will return a random joke without any jokes filtered out
                Joke randomJoke = JokeProvider.GetRandomJoke(new List<Joke>(), acceptLang, allowedCategories);
                jokes.Add(randomJoke);

                HttpContext.Session.SetObjectAsJson("Jokes", jokes);

                //Finally return the random joke we just found
                return StatusCode(200, randomJoke.JokeMessage);
            }
        }

        // GET api/<JokeController>/5
        [HttpGet]
        [Route("GetCategories")]
        public IEnumerable<string> GetCategories()
        {
            //Eventually only return the categories the api key allows
            //Returns all the category names
            return Enum.GetNames(typeof(JokeCategory));
        }

        //HERE YOU CAN CHANGE SETTINGS 
        // POST api/<JokeController>
        [HttpPost]
        public void Post([FromQuery] string category)
        {
            if (category != null)
            {
                CookieOptions co = new CookieOptions();
                //The cookie should last 10 minutes
                co.MaxAge = TimeSpan.FromMinutes(10);

                Response.Cookies.Append("favCategory", category, co);
            }
        }

        // DELETE api/<JokeController>
        [HttpDelete()]
        public void Delete()
        {
            CookieOptions co = new CookieOptions();
            //Making the age 0 deletes the cookie
            co.MaxAge = TimeSpan.FromSeconds(0);
            Response.Cookies.Append("favCategory", "", co);
        }
    }
}
