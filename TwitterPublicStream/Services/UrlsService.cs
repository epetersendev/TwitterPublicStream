using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi.Models;
using TwitterPublicStream.Models;
using TwitterPublicStream.Repositories;

namespace TwitterPublicStream.Services
{
    public class UrlsService : IUrlsService
    {
        private readonly IUrlsRepository _urlsRepository;

        public UrlsService(IUrlsRepository urlsRepository)
        {
            _urlsRepository = urlsRepository ?? throw new ArgumentNullException(nameof(urlsRepository));
        }

        public bool ContainsUrls(ITweet tweet)
        {
            return tweet.Urls.Count > 0;
        }

        public void TrackUrls(ITweet tweet)
        {
            if (tweet.Urls.Count <= 0) return;
            foreach (var url in tweet.Urls)
            {
                var uri = new Uri(url.ExpandedURL);
                _urlsRepository.Create(new Url { Domain = uri.Host});
            }
        }

        public IEnumerable<string> GetTop5()
        {
            return _urlsRepository.ReadAll().ToList().GroupBy(u => u.Domain).OrderByDescending(gp => gp.Count()).Take(5).Select(g => g.Key).ToList();
        }
    }
}
