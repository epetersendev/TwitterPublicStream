using System;
using System.Collections.Generic;

namespace TwitterPublicStream.Models
{
    public class StreamStatistics
    {
        public DateTime StartTime { get; set; }
        public double TotalTweets { get; set; }
        public double TweetsPerHour { get; set; }
        public double TweetsPerMinute { get; set; }
        public double TweetsPerSecond { get; set; }
        public IEnumerable<string> TopEmojis { get; set; }
        public IEnumerable<string> TopHashTags { get; set; }
        public IEnumerable<string> TopUrls { get; set; }
        public double PercentageOfTweetsThatContainEmojis { get; set; }
        public double PercentageOfTweetsThatContainUrls { get; set; }
        public double PercentageOfTweetsThatContainPhotos { get; set; }

    }
}
