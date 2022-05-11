using System.Collections.Generic;

namespace DictatorTweetApi
{
    public class TwitterChatMessages
    {
        //This naming is for json deserializer to recognize, could also use [JsonPropertyName("")]
        public List<TwitterMessage> Data120161205TrumpTwitterAll { get; set; }
    }
}
