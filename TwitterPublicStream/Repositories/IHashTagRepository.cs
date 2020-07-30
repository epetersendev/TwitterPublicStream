using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public interface IHashTagRepository
    {
        void Create(HashTag hashTag);
        IEnumerable<HashTag> ReadAll();
    }
}
