using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    class PartySeriesReference : IDemozooApiReference
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        public PartySeries PartySeries => DemozooApi.Dereference<PartySeries>(this);

        [DeserializeAs(Name = "demozoo_url")]
        public string DemozooUrl { get; private set; }
        
        public long ID { get; private set; }

        public string Name { get; private set; }

        public string Website { get; private set; }
    }
}
