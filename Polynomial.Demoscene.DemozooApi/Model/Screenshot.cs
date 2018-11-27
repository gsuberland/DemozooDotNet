using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    class Screenshot
    {
        [DeserializeAs(Name = "original_url")]
        public string OriginalUrl { get; private set; }
        [DeserializeAs(Name = "original_width")]
        public long OriginalWidth { get; private set; }
        [DeserializeAs(Name = "original_height")]
        public long OriginalHeight { get; private set; }

        [DeserializeAs(Name = "standard_url")]
        public string StandardUrl { get; private set; }
        [DeserializeAs(Name = "standard_width")]
        public long StandardWidth { get; private set; }
        [DeserializeAs(Name = "standard_height")]
        public long StandardHeight { get; private set; }

        [DeserializeAs(Name = "thumbnail_url")]
        public string ThumbnailUrl { get; private set; }
        [DeserializeAs(Name = "thumbnail_width")]
        public long ThumbnailWidth { get; private set; }
        [DeserializeAs(Name = "thumbnail_height")]
        public long ThumbnailHeight { get; private set; }
    }
}
