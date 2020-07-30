using Tweetinvi.Models;

namespace TwitterPublicStream.Services
{
    public class MediaService : IMediaService
    {
        public bool ContainsPhoto(ITweet tweet)
        {
            return tweet.Media.Count > 0;
        }
    }
}
