using DictatorTweetApi.Services;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace DictatorTweetApi
{
    public class TweetSocket : WebSocketBehavior
    {
        private readonly TweetService tweetService;
        private readonly Thread twitterThread;

        public TweetSocket()
        {
            tweetService = new TweetService();
            twitterThread = new Thread(sendTweets);
            twitterThread.Start();
        }
        protected override void OnOpen()
        {
        }
        void sendTweets()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Send(JsonConvert.SerializeObject(tweetService.GetTwitterMessage()));
            }
        }
    }
    public class WebSocketServerV2 : IWebSocketServer
    {
        private readonly Thread twitterThread;
        WebSocketServer webSocketServer = new WebSocketServer("ws://127.0.0.1:7890");
        public WebSocketServerV2()
        {
            webSocketServer.AddWebSocketService<TweetSocket>("/tweet");
            webSocketServer.Start();

        }

        public void Start()
        {
            //twitterThread.Start();
        }

        void sendTweets()
        {
            while (true)
            {
                Thread.Sleep(1000);
                //Send(Encoding.UTF8.GetBytes("jens"));
            }
        }
    }
}
