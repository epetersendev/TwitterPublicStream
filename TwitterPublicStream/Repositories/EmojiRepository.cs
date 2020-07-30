using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public class EmojiRepository : IEmojiRepository
    {
        private readonly List<Emoji> _emojis = new List<Emoji>();

        public void Create(Emoji emoji)
        {
            _emojis.Add(emoji);
        }

        public IEnumerable<Emoji> ReadAll()
        {
            return _emojis;
        }
    }
}
