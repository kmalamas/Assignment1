# Assignment1
This is not a complete solution. Currently it is using the TweetInvi library to authenticate and create a filtered stream. 
The only UI is through the consoleApp which accepts a term to filter and then prints the url of any photo contained in one of
the tweets that are filtered through the streams. TweetInvi also uses Newtonsoft to map all the models from Twitter API so it is
quite easy to access the entities and their properties.

The main idea would be to 
1) Create a filtered stream to get the relevant tweets. 
2) Extract the urls of the pictures (perhaps the picture itself in binary form as well) and save them.
3) From there the pictures could be processed for face and genders(not sure about that part yet). Depending on the how 
long the processing takes a queing system would be good for load balancing.
4) After a certain interval calculate the hourly rate of posts and genders based on their count. Using the stream.MatchingTweetReceived 
event to increment the counter and probably an Timer or Watchdog to count time.
5) Now we have all the data we need. A asp.Net core based site would probably run on both Mac and Windows, not sure about iOS.
6) In order to update the search term we would terminate the stream and make a new one. We can just add a new track term but we would have to 
reset timers/counters for rates.
7) As for the real-time update in the website, either polling or push is required. I found that in many cases SignalR library provides such 
functionality but need to check it out. The pictures URLs (these do not require to go through oAuth) are saved so we can embed them 
in the site to show. 
