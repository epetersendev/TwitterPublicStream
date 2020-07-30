using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NeoSmart.Unicode;
using TwitterPublicStream.Repositories;

namespace TwitterPublicStream.Services
{
    public class EmojiService : IEmojiService
    {
        const string Emojipattern = @"(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])";
        private readonly IEmojiRepository _emojiRepository;

        public EmojiService(IEmojiRepository emojiRepository)
        {
            _emojiRepository = emojiRepository ?? throw new ArgumentNullException(nameof(emojiRepository));
        }

        public bool ContainsEmojis(string message)
        {
            var rgx = new Regex(Emojipattern);
            foreach (Match match in rgx.Matches(message))
            {
                if (Emoji.IsEmoji(match.Value))
                {
                    return true;
                }
            }
            return false;
        }

        public void TrackEmojis(string message)
        {
            var rgx = new Regex(Emojipattern);
            foreach (Match match in rgx.Matches(message))
            {
                if (!Emoji.IsEmoji(match.Value)) continue;
                foreach (var emoji in Emoji.All)
                {
                    if (emoji.Sequence.AsString != match.Value) continue;
                    _emojiRepository.Create(new Models.Emoji { Name = emoji.Name });
                    break;
                }
            }
        }

        public IEnumerable<string> GetTop5()
        {
            return _emojiRepository.ReadAll().ToList().GroupBy(se => se.Name).OrderByDescending(gp => gp.Count()).Take(5).Select(g => g.Key).ToList();
        }
    }
}
