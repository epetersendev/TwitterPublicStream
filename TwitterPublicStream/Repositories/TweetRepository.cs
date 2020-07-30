using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly List<Tweet> _tweets = new List<Tweet>();

        public void Create(Tweet tweet)
        {
            _tweets.Add(tweet);
        }

        public IEnumerable<Tweet> ReadAll()
        {
            return _tweets;
        }
    }
}
