using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    public class Platform
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        public long ID { get; private set; }

        public string Name { get; private set; }
    }
}
