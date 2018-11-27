using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    class Production
    {
        [DeserializeAs(Name = "url")]
        public string ApiUrl { get; private set; }

        [DeserializeAs(Name = "demozoo_url")]
        public string DemozooUrl { get; private set; }

        public long ID { get; private set; }

        public string Title { get; private set; }

        [DeserializeAs(Name = "author_nicks")]
        public List<Nick> AuthorNicks { get; private set; }

        [DeserializeAs(Name = "release_date")]
        public DateTime ReleaseDate { get; private set; }

        public string Supertype { get; private set; }

        public List<Platform> Platforms { get; private set; }

        public List<ProductionType> Types { get; private set; }

        public List<Credit> Credits { get; private set; }

        [DeserializeAs(Name = "download_links")]
        public List<DownloadLink> DownloadLinks { get; private set; }

        [DeserializeAs(Name = "competition_placings")]
        public List<CompetitionPlacing> CompetitionPlacings { get; private set; }

        public List<Screenshot> Screenshots { get; private set; }
    }
}
