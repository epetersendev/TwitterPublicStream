using System.Collections.Generic;
using Tweetinvi.Models;

namespace TwitterPublicStream.Services
{
    public interface IUrlsService
    {
        bool ContainsUrls(ITweet tweet);
        void TrackUrls(ITweet tweet);
        IEnumerable<string> GetTop5();

    }
}
