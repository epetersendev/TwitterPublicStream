using System.Collections.Generic;
using Tweetinvi.Models;

namespace TwitterPublicStream.Services
{
    public interface IHashTagService
    {
        bool ContainsHashTags(ITweet tweet);
        void TrackHashTags(ITweet tweet);
        IEnumerable<string> GetTop5();
    }
}
