using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    class Party
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }
        
        public long ID { get; private set; }

        public string Name { get; private set; }

        public string Tagline { get; private set; }
        
        [DeserializeAs(Name = "party_series")]
        public PartySeriesReference PartySeries { get; private set; }
    }
}
