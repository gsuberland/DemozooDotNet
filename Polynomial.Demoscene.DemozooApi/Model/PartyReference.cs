using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    class PartyReference : IApiReference
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        public Party Party { get { return DemozooApi.Dereference<Party>(this); } }

        public long ID { get; private set; }
        public string Name { get; private set; }
    }
}
