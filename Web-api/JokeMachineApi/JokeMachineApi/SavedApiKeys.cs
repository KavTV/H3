namespace JokeMachineApi
{
    public class SavedApiKeys
    {

        public readonly IDictionary<string, ApiKey> apiKeys;

        //IN THE REAL WORLD I WOULD USE A DATABASE FOR THIS..
        public SavedApiKeys()
        {
            var existingApiKeys = new List<ApiKey>
        {
            new ApiKey(1, "Kasper", "G3BFF7F0-B6DF-469E-A331-F737424F013H", new DateTime(2022, 01, 27),
                new List<JokeCategory>
                {
                    JokeCategory.Dark,
                    JokeCategory.Dad,
                    JokeCategory.Funny
                }),
            new ApiKey(2, "Camilla", "FA872702-A770-6396-85D3-03C6ABDB1BAE", new DateTime(2022, 01, 27),
                new List<JokeCategory>
                {
                    JokeCategory.Funny
                }),
            new ApiKey(3, "Philip", "06795D9D-A790-44B9-8C2B-FC1BE900591B", new DateTime(2022, 01, 27),
                new List<JokeCategory>
                {
                    JokeCategory.Dark
                }),

        };

            apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }


    }
}
