using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public interface IEmojiRepository
    {
        void Create(Emoji emoji);
        IEnumerable<Emoji> ReadAll();
    }
}
