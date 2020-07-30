namespace TwitterPublicStream.Models
{
    public class Tweet
    {
        public bool ContainsEmojis { get; set; }
        public bool ContainsUrls { get; set; }
        public bool ContainsPhotos { get; set; }
        public bool ContainsHashTags { get; set; }
    }
}
