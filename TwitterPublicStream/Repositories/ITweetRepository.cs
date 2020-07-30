using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public interface ITweetRepository
    {
        void Create(Tweet tweet);
        IEnumerable<Tweet> ReadAll();
    }
}
