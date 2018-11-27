using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    class ProductionType
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        public long ID { get; private set; }
        public string Name { get; private set; }
        public string Supertype { get; private set; }
    }
}
