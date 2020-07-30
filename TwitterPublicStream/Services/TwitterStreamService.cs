using System;
using System.Collections.Concurrent;
using System.Threading;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Services
{

    public class TwitterStreamService : ITwitterStreamService
    {
        private readonly ITweetService _tweetService;
        private readonly IEmojiService _emojiService;
        private readonly IHashTagService _hashTagService;
        private readonly IUrlsService _urlsService;
        private readonly StreamStatistics _streamStatistics = new StreamStatistics();

        public TwitterStreamService(ITweetService tweetService, IEmojiService emojiService, IHashTagService hashTagService, IUrlsService urlsService)
        {
            _tweetService = tweetService ?? throw new ArgumentNullException(nameof(tweetService));
            _emojiService = emojiService ?? throw new ArgumentNullException(nameof(emojiService));
            _hashTagService = hashTagService ?? throw new ArgumentNullException(nameof(hashTagService));
            _urlsService = urlsService ?? throw new ArgumentNullException(nameof(urlsService));
        }

        public void StartStream()
        {
            var tweetQueue = new ConcurrentQueue<ITweet>(); ;
            var consumer = new Thread(() =>
            {
                while (true)
                {
                    if (tweetQueue.TryDequeue(out var tweet))
                    {
                         _tweetService.ProcessTweet(tweet);
                    }
                }
            });
            consumer.Start();

            Auth.SetUserCredentials("mZKa0BAKFdMDqQtqkCYWZSimE", "2IfkTuBghLUZU78gUL1zjXUVUR97b8WTB2vOszJRFodQ7JPTFL", "1288287168813817856-WX3OKORCnbDDT7DysjmtQAPEBtY7a4", "w1KFnA49dQmqMQbwro09yP0v6DlT0MBZ5ssuXu6xyykLg");
            var stream = Stream.CreateSampleStream();
            stream.TweetReceived += (sender, theTweet) =>
            {
                tweetQueue.Enqueue(theTweet.Tweet);
            };
            _streamStatistics.StartTime = DateTime.Now;
            stream.StartStream();
        }

        public StreamStatistics CalculateStreamStatistics()
        {
            CalculateVolume();
            _streamStatistics.TopEmojis = _emojiService.GetTop5();
            _streamStatistics.TopHashTags = _hashTagService.GetTop5();
            _streamStatistics.TopUrls = _urlsService.GetTop5();
            _streamStatistics.PercentageOfTweetsThatContainEmojis = _tweetService.CalculatePercentationOfTweetsThatContainEmojis();
            _streamStatistics.PercentageOfTweetsThatContainUrls = _tweetService.CalculatePercentationOfTweetsThatContainUrls();
            return _streamStatistics;
        }

        private void CalculateVolume()
        {
            _streamStatistics.TotalTweets = _tweetService.TotalTweets;
            var timeRunning = (DateTime.Now - _streamStatistics.StartTime);
            _streamStatistics.TweetsPerHour = Math.Round(_streamStatistics.TotalTweets / timeRunning.TotalHours, MidpointRounding.AwayFromZero);
            _streamStatistics.TweetsPerMinute = Math.Round(_streamStatistics.TotalTweets / timeRunning.TotalMinutes, MidpointRounding.AwayFromZero);
            _streamStatistics.TweetsPerSecond = Math.Round(_streamStatistics.TotalTweets / timeRunning.TotalSeconds, MidpointRounding.AwayFromZero);
        }

    }
}
