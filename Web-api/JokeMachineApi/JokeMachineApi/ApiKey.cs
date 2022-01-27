namespace JokeMachineApi
{
    public class ApiKey
    {
        public int Id { get; }
        public string Owner { get; }
        public string Key { get; }
        public DateTime Created { get; }
        public List<JokeCategory> AllowedCategories { get; set; }

        public ApiKey(int id, string owner, string key, DateTime created, List<JokeCategory> allowedCategories)
        {
            Id = id;
            Owner = owner;
            Key = key;
            Created = created;
            AllowedCategories = allowedCategories;
        }

    }
}
