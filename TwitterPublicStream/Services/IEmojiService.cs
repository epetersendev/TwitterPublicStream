using System.Collections.Generic;

namespace TwitterPublicStream.Services
{
    public interface IEmojiService
    {
        bool ContainsEmojis(string message);
        void TrackEmojis(string message);
        IEnumerable<string> GetTop5();
    }
}
