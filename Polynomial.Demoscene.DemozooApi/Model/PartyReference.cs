using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    class PartyReference : IDemozooApiReference
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        public Party Party => DemozooApi.Dereference<Party>(this);

        public long ID { get; private set; }

        public string Name { get; private set; }
    }
}
