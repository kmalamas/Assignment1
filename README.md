# Assignment1
This is not a complete solution. Currently it is using the TweetInvi library to authenticate and create a filtered stream. 
The only UI is through the consoleApp which accepts a term to filter and then prints the url of any photo contained in one of
the tweets that are filtered through the streams. TweetInvi also uses Newtonsoft to map all the models from Twitter API so it is
quite easy to access the entities and their properties.

The main idea would be to 
1) Create a filtered stream to get the relevant tweets. 
2) Extract the urls of the pictures (perhaps the picture itself in binary form as well) and save them.
3) From there the pictures could be processed for face and genders(not sure about that part yet). Depending on the how 
long the processing takes a queing system might be required.
4) After a certain interval calculate the hourly rate of posts and genders based on their count. Using the stream.MatchingTweetReceived 
event to increment the counter and probably an Timer or Watchdog to count time.
5) Now we have all the data we need. A asp.Net core based WebApplication would probably run on both Mac and Windows, not sure about iOS.
6) In order to update the search term we would terminate the stream and make a new one. We can just add a new track term but we would have to reset timers/counters for rates. Also, depends on Twitter API rate limit.
7) As for the real-time update in the website, either polling or push is required. I found that in many cases SignalR library provides such functionality but need to check it out. The pictures URLs (these do not require to go through oAuth) are saved so we can embed them 
in the site to show. 

Notes about the image processing part:
Although tag functionality is available on Twitter, i couldnt find such info in the API. They might be store in the prefix of the tweet but need to check this out. If that is the case then REST API can be used to retrieve tagged user infos and their gender. That doesnt mean though that the tagged user is going to be in the photo. 

The other way would be to use some package for image processing to detect faces, not sure about their gender though. Also that would increase the processing time and could cause other issues.

Another thing to look into is Azure stream analytics, to see what it it offers and what kind of data it can provide. But thats probably mostly for statistic for the stream.
