using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public class HashTagRepository : IHashTagRepository
    {
        private readonly List<HashTag> _hashTags = new List<HashTag>();

        public void Create(HashTag hashTag)
        {
            _hashTags.Add(hashTag);
        }

        public IEnumerable<HashTag> ReadAll()
        {
            return _hashTags;
        }

    }
}
