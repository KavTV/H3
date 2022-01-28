using System.Globalization;
namespace JokeMachineApi
{

    public class Joke
    {
        public int Id { get; set; }
        public string JokeMessage { get; set; }
        public CultureInfo CultureInfo { get; set; }
        public JokeCategory Category { get; set; }

        public Joke(int id, string joke, CultureInfo language, JokeCategory category)
        {
            Id = id;
            JokeMessage = joke;
            CultureInfo = language;
            Category = category;
        }

    }
}
