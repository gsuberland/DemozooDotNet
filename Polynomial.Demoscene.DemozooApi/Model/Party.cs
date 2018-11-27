using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    public class Party
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }
        
        public long ID { get; private set; }

        public string Name { get; private set; }

        public string Tagline { get; private set; }
        
        [DeserializeAs(Name = "party_series")]
        public PartySeriesReference PartySeries { get; private set; }

        [DeserializeAs(Name = "start_date")]
        public DateTime StartDate { get; private set; }

        [DeserializeAs(Name = "end_date")]
        public DateTime EndDate { get; private set; }

        public string Location { get; private set; }

        public bool IsOnline { get; private set; }

        [DeserializeAs(Name = "country_code")]
        public string CountryCode { get; private set; }
        
        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string Website { get; private set; }

        public List<Production> Invitations { get; private set; }

        public List<Production> Releases { get; private set; }

        public List<Competition> Competitions { get; private set; }
    }
}
