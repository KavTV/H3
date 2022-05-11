namespace DictatorTweetApi.Controllers
{
    public class Dictator
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TwitterKey { get; set; }

        public Dictator(string name,string description, string twitterKey)
        {
            this.Name = name;
            this.Description = description;
            this.TwitterKey = twitterKey;
        }
    }
}
