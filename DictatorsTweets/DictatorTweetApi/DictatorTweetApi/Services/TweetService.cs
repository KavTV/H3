﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DictatorTweetApi.Services
{
    public interface ITweetService
    {
        TwitterMessage GetTwitterMessage();
        Stack<string> GetDictatorKeys();
    }
    public class TweetService : ITweetService
    {
        static List<TwitterMessage> twitterMessages;

        public TweetService()
        {
            if (twitterMessages == null)
            {
                //Deserialize all tweets and save them in a list
                string jsonString = File.ReadAllText(@"C:\Users\krj\Documents\Github\H3\DictatorsTweets\tweets.json");
                TwitterChatMessages msg = JsonConvert.DeserializeObject<TwitterChatMessages>(jsonString);
                twitterMessages = msg.Data120161205TrumpTwitterAll;
            }
        }

        /// <summary>
        /// Get all the different keys for the dictators to be assigned
        /// </summary>
        public Stack<string> GetDictatorKeys()
        {
            Stack<string> dicKeys = new Stack<string>();

            foreach (var message in twitterMessages)
            {
                //if message does not contain the key, then add it to the list of keys available for dictators
                if (!dicKeys.Contains(message.Client))
                {
                    dicKeys.Push(message.Client);
                }
            }

            return dicKeys;
        }

        public TwitterMessage GetTwitterMessage()
        {
            if (twitterMessages.Count == 0)
            {
                return null;
            }


            Random rnd = new Random();
            TwitterMessage ts = twitterMessages[rnd.Next(twitterMessages.Count)];
            twitterMessages.Remove(ts);
            return ts;
        }
    }
}
