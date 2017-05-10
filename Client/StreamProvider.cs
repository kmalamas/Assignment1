using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tweetinvi;

namespace Client
{
    public static class StreamProvider
    {
        public static void CreateFilteredStream(string filter)
        {
            int counter = 0;// this will go over bounds if stream is open too long
            
            var stream = Stream.CreateFilteredStream();
            stream.AddTrack(filter);
            DateTime then = DateTime.Now; // the start time
            stream.MatchingTweetReceived += (sender, arg) =>
            {
                counter++;
                Console.WriteLine(CalculateTweetsPerHour(counter, then));
                if (arg.Tweet.Entities.Medias.Count>0)
                    Console.WriteLine("A tweet " + arg.Tweet.Entities.Medias.First().MediaURL + "'");
                //Console.WriteLine("A tweet containing '"+ filter+"' has been found; the tweet is '" + arg.Tweet + "'");
            };

            stream.StartStreamMatchingAllConditions();
           
           
        }

        public static double CalculateTweetsPerHour(int tweetsCounter, DateTime then)
        {
            double elapsedSeconds = (DateTime.Now - then).TotalSeconds;
            double rate = (tweetsCounter * 3600) / elapsedSeconds; //definately not ideal
            return rate;
        }

    }
}
