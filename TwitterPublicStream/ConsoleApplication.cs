using System;
using System.Timers;
using TwitterPublicStream.Services;

namespace TwitterPublicStream
{
    public class ConsoleApplication
    {
        private readonly ITwitterStreamService _twitterStreamService;

        public ConsoleApplication(ITwitterStreamService twitterStreamService)
        {
            _twitterStreamService = twitterStreamService;
        }

        public void Run()
        {
            var displayStatisticsTimer = new Timer();
            displayStatisticsTimer.Elapsed += DisplayStatistics;
            displayStatisticsTimer.Interval = 15000;
            displayStatisticsTimer.Enabled = true;
            _twitterStreamService.StartStream();
        }

        private void DisplayStatistics(object sender, ElapsedEventArgs e)
        {
            var streamStatistics = _twitterStreamService.CalculateStreamStatistics();
            Console.WriteLine($"Total tweats recieved {streamStatistics.TotalTweets}");
            Console.WriteLine($"Total tweats recieved per hour {streamStatistics.TweetsPerHour}");
            Console.WriteLine($"Total tweats recieved per minutes {streamStatistics.TweetsPerMinute}");
            Console.WriteLine($"Total tweats recieved per second {streamStatistics.TweetsPerSecond}");
            Console.WriteLine($"Percentage of tweets that contain emojis {streamStatistics.PercentageOfTweetsThatContainEmojis}%");
            Console.WriteLine($"Percentage of tweets that contain urls {streamStatistics.PercentageOfTweetsThatContainUrls}%");
            Console.WriteLine($"Percentage of tweets that contain photo {streamStatistics.PercentageOfTweetsThatContainPhotos}%");
            Console.WriteLine();
            Console.WriteLine($"Most popular emojis:");
            foreach (var emoji in streamStatistics.TopEmojis)
            {
                Console.WriteLine(emoji);
            }
            Console.WriteLine();
            Console.WriteLine($"Most popular hashtags:");
            foreach (var hashtag in streamStatistics.TopHashTags)
            {
                Console.WriteLine(hashtag);
            }
            Console.WriteLine();
            Console.WriteLine($"Most popular urls:");
            foreach (var domain in streamStatistics.TopUrls)
            {
                Console.WriteLine(domain);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
