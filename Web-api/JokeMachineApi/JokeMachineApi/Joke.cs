namespace JokeMachineApi
{
    public class Joke
    {
        public int Id { get; set; }
        public string JokeMessage { get; set; }
        public Language Language { get; set; }
        public JokeCategory Category { get; set; }

        public Joke(int id, string joke, Language language, JokeCategory category)
        {
            Id = id;
            JokeMessage = joke;
            Language = language;
            Category = category;
        }

    }
}
