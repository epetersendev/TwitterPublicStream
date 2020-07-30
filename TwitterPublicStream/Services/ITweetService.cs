using Tweetinvi.Models;

namespace TwitterPublicStream.Services
{
    public interface ITweetService
    {
        double TotalTweets { get; }
        void ProcessTweet(ITweet tweet);
        double CalculatePercentationOfTweetsThatContainEmojis();
        double CalculatePercentationOfTweetsThatContainUrls();
        double CalculatePercentationOfTweetsThatContainPhotos();
    }
}
