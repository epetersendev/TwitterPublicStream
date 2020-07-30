using System.Collections.Generic;
using TwitterPublicStream.Models;

namespace TwitterPublicStream.Repositories
{
    public class UrlsRepository : IUrlsRepository
    {
        private readonly List<Url> _urls = new List<Url>();

        public void Create(Url url)
        {
            _urls.Add(url);
        }

        public IEnumerable<Url> ReadAll()
        {
            return _urls;
        }
    }
}
