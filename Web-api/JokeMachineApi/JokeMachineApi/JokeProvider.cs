using System.Globalization;
using System.Net.Http.Headers;

namespace JokeMachineApi
{
    public class JokeProvider
    {

        /// <summary>
        /// Finds the jokes that is not used yet
        /// </summary>
        /// <param name="usedJokes"></param>
        /// <returns>The jokes that the user have not seen yet</returns>
        public static List<Joke> GetRemainingJokes(List<Joke> usedJokes)
        {
            //Get the jokes from database
            //For each joke if we find a matching id with usedjokes, then the joke is already used.
            List<Joke> jokes = Dal.jokes.FindAll(joke => usedJokes.Find(usedJoke => usedJoke.Id == joke.Id) == null);
            return jokes;
        }

        /// <summary>
        /// Finds a random joke that is not seen before by getting a list of all the used jokes
        /// </summary>
        /// <param name="usedJokes">List with already used jokes</param>
        /// <returns>A joke that the user have not seen</returns>
        public static Joke GetRandomJoke(List<Joke> usedJokes, CultureInfo language, List<JokeCategory> allowedCategories)
        {
            //Get the jokes user have not seen yet
            List<Joke> jokes = GetRemainingJokes(usedJokes);

            //Now filter out all jokes that do not have the preferred language and only show allowed categories
            jokes = jokes.FindAll(joke => joke.CultureInfo.Name == language.Name && allowedCategories.Contains(joke.Category));

            return RandomJoke(jokes);
        }

        public static Joke GetRandomJokeFromCategory(List<Joke> usedJokes, CultureInfo language, JokeCategory category)
        {
            //Get the jokes user have not seen yet
            List<Joke> jokes = GetRemainingJokes(usedJokes);

            //Now filter out all jokes that do not have the preferred language
            jokes = jokes.FindAll(joke => joke.CultureInfo.Name == language.Name && joke.Category == category);

            return RandomJoke(jokes);
        }

        private static Joke RandomJoke(List<Joke> jokes)
        {
            Random random = new Random();
            //If list is not empty we can return a joke, otherwise we cant
            if (jokes.Count > 0)
            {
                return jokes[random.Next(0, jokes.Count)];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Helps translate the language from the accept-language header
        /// </summary>
        /// <param name="acceptLanguage"></param>
        /// <returns>the main language</returns>
        public static CultureInfo GetLanguage(string acceptLanguage)
        {

            //CultureInfo ci = new CultureInfo(acceptLanguage);
            //In this case we just take the first language, and dont care about quality (q=)
            string language = "da-DK";
            if (acceptLanguage != null)
            {
                language = acceptLanguage.Split(",")[0];
            }

            return new CultureInfo(language);

        }

        public static JokeCategory GetCategory(string category)
        {
            try
            {
                //This looks at the string and tries to match it with one of the enums in jokecategory
                //Will throw exception if no match were found
                JokeCategory jokeCategory = (JokeCategory)Enum.Parse(typeof(JokeCategory), category);

                return jokeCategory;
            }
            catch (Exception)
            {
                //Default funny category
                return JokeCategory.Any;
            }

            
        }
    }
}
