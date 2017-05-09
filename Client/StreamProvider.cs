using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace Client
{
    public static class StreamProvider
    {
        public static void CreateFilteredStream(string filter)
        {
            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(filter);
            stream.MatchingTweetReceived += (sender, arg) =>
            {
                Console.WriteLine("A tweet containing '"+ filter+"' has been found; the tweet is '" + arg.Tweet + "'");
            };
            stream.StartStreamMatchingAllConditions();
        }

    }
}
