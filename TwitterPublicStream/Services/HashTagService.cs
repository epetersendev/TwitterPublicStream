using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Models;
using TwitterPublicStream.Models;
using TwitterPublicStream.Repositories;

namespace TwitterPublicStream.Services 
{
    public class HashTagService : IHashTagService
    {
        private readonly IHashTagRepository _hashTagRepository;

        public HashTagService(IHashTagRepository hashTagRepository)
        {
            _hashTagRepository = hashTagRepository ?? throw new ArgumentNullException(nameof(hashTagRepository));
        }


        public bool ContainsHashTags(ITweet tweet)
        {
            return tweet.Hashtags.Count > 0;
        }

        public void TrackHashTags(ITweet tweet)
        {
            if (tweet.Hashtags.Count <= 0) return;
            foreach (var hastag in tweet.Hashtags)
            {
                _hashTagRepository.Create(new HashTag { Text = hastag.Text});
            }
        }

        public IEnumerable<string> GetTop5()
        {
            return _hashTagRepository.ReadAll().ToList().GroupBy(ht => ht.Text).OrderByDescending(gp => gp.Count()).Take(5).Select(g => g.Key).ToList();
        }
    }
}
