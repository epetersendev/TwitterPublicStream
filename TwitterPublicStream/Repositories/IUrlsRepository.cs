using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public interface IUrlsRepository
    {
        void Create(Url hashTag);
        IEnumerable<Url> ReadAll();
    }
}
