using Tweetinvi.Models;

namespace TwitterPublicStream.Services
{
    public interface IMediaService
    {
        bool ContainsPhoto(ITweet tweet);
    }
}
