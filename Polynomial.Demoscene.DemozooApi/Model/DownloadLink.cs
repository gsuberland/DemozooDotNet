using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    public class DownloadLink
    {
        [DeserializeAs(Name = "link_class")]
        public string LinkClass { get; private set; }
        public string URL { get; private set; }
    }
}
