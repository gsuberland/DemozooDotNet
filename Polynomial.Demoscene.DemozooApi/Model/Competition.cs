using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    public class Competition
    {
        public long ID { get; private set; }

        [DeserializeAs(Name = "demozoo_url")]
        public string DemozooUrl { get; private set; }

        public string Name { get; private set; }

        [DeserializeAs(Name = "shown_date")]
        public DateTime ShownDate { get; private set; }

        public string Platform { get; private set; } // todo: see if this is actually a ref to Platform

        [DeserializeAs(Name = "production_type")]
        public ProductionType ProductionType { get; private set; }
        
        public List<CompetitionResult> Results { get; private set; }
    }
}
