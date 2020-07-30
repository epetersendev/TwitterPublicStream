using System;
using System.Linq;
using Tweetinvi.Models;
using TwitterPublicStream.Models;
using TwitterPublicStream.Repositories;

namespace TwitterPublicStream.Services
{
    public class TweetService : ITweetService
    {
        private readonly IMediaService _mediaService;
        private readonly IEmojiService _emojiService;
        private readonly IHashTagService _hashTagService;
        private readonly IUrlsService _urlsService;
        private readonly ITweetRepository _tweetRepository;

        public TweetService(ITweetRepository tweetRepository, IEmojiService emojiService, IHashTagService hashTagService, IUrlsService urlsService, IMediaService mediaService)
        {
            _emojiService = emojiService ?? throw new ArgumentNullException(nameof(emojiService));
            _tweetRepository = tweetRepository ?? throw new ArgumentNullException(nameof(tweetRepository));
            _hashTagService = hashTagService ?? throw new ArgumentNullException(nameof(hashTagService));
            _urlsService = urlsService ?? throw new ArgumentNullException(nameof(urlsService));
            _mediaService = mediaService ?? throw new ArgumentNullException(nameof(mediaService));
        }

        public double TotalTweets => _tweetRepository.ReadAll().Count();

        public void ProcessTweet(ITweet tweet)
        {
            var vtweet = new Tweet();
            if (_emojiService.ContainsEmojis(tweet.FullText))
            {
                vtweet.ContainsEmojis = true;
                _emojiService.TrackEmojis(tweet.FullText);
            }
            if (_hashTagService.ContainsHashTags(tweet))
            {
                vtweet.ContainsHashTags = true;
                _hashTagService.TrackHashTags(tweet);
            }
            if (_urlsService.ContainsUrls(tweet))
            {
                vtweet.ContainsUrls = true;
                _urlsService.TrackUrls(tweet);
            }
            vtweet.ContainsPhotos = _mediaService.ContainsPhoto(tweet);
            _tweetRepository.Create(vtweet);
        }

        public double CalculatePercentationOfTweetsThatContainEmojis()
        {
            var tweets = _tweetRepository.ReadAll().ToList();
            var tweetCount = tweets.Count();
            var tweetsWithEmojisCount = tweets.Count(t => t.ContainsEmojis);
            var percentageOfTweetsWithEmojis = (double)tweetsWithEmojisCount / (double)tweetCount;
            return Math.Round(percentageOfTweetsWithEmojis * 100, MidpointRounding.AwayFromZero);
        }

        public double CalculatePercentationOfTweetsThatContainUrls()
        {
            var tweets = _tweetRepository.ReadAll().ToList();
            var tweetCount = tweets.Count();
            var tweetsWithEmojisCount = tweets.Count(t => t.ContainsUrls);
            var percentageOfTweetsWithEmojis = (double)tweetsWithEmojisCount / (double)tweetCount;
            return Math.Round(percentageOfTweetsWithEmojis * 100, MidpointRounding.AwayFromZero);
        }

        public double CalculatePercentationOfTweetsThatContainPhotos()
        {
            var tweets = _tweetRepository.ReadAll().ToList();
            var tweetCount = tweets.Count();
            var tweetsWithEmojisCount = tweets.Count(t => t.ContainsPhotos);
            var percentageOfTweetsWithEmojis = (double)tweetsWithEmojisCount / (double)tweetCount;
            return Math.Round(percentageOfTweetsWithEmojis * 100, MidpointRounding.AwayFromZero);
        }

    }
}
