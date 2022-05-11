using DictatorTweetApi.Controllers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DictatorTweetApi.Services
{
    public interface IDictatorService
    {
        Dictator CreateDictator(string dictatorName, string description);
        bool DeleteDictator(string dictatorName);
        IEnumerable<Dictator> GetAllDictators();
        Dictator UpdateDictator(string dictatorName, string newName, string newDesc);

    }
    public class DictatorService : IDictatorService
    {
        static List<Dictator> dictators = new List<Dictator>();
        static Stack<string> dictatorKeys = new Stack<string>();

        public DictatorService()
        {
            getDictatorKeys();
        }

        /// <summary>
        /// Get all the different keys for the dictators to be assigned
        /// </summary>
        private void getDictatorKeys()
        {
            //Deserialize all tweets, to find all the available twitter keys
            string jsonString = File.ReadAllText(@"C:\Users\krj\Documents\Github\H3\DictatorsTweets\tweets.json");
            TwitterChatMessages msg = JsonConvert.DeserializeObject<TwitterChatMessages>(jsonString);

            foreach (var message in msg.Data120161205TrumpTwitterAll)
            {
                //if message does not contain the key, then add it to the list of keys available for dictators
                if (!dictatorKeys.Contains(message.Client))
                {
                    dictatorKeys.Push(message.Client);
                }
            }
        }

        /// <summary>
        /// Takes a key from the list
        /// </summary>
        /// <returns></returns>
        private string getDictatorKey()
        {
            if (dictatorKeys.Count == 0)
            {
                return null;
            }
            return dictatorKeys.Pop();
        }

        public Dictator CreateDictator(string dictatorName, string description)
        {
            string key = getDictatorKey();
            //If there are no keys
            if (key == null)
            {
                return null;
            }

            //Get a key for the dictator tweets

            Dictator newDic = new Dictator(dictatorName, description, key);
            dictators.Add(newDic);

            return newDic;
        }

        public bool DeleteDictator(string dictatorName)
        {
            //Try to find the dictator with the name
            Dictator foundDic = dictators.Find(dic => dic.Name == dictatorName);
            if (foundDic != null)
            {
                dictatorKeys.Push(foundDic.TwitterKey);
                dictators.Remove(foundDic);
                return true;
            }

            return false;
        }

        public IEnumerable<Dictator> GetAllDictators()
        {
            return dictators;
        }

        public Dictator UpdateDictator(string dictatorName, string newName, string newDesc)
        {
            //Try to find the dictator with the name
            int foundDic = dictators.FindIndex(dic => dic.Name == dictatorName);
            if (foundDic != -1)
            {
                dictators[foundDic].Name = newName;
                dictators[foundDic].Description = newDesc;
                return dictators[foundDic];
            }

            return null;
        }
    }
}
