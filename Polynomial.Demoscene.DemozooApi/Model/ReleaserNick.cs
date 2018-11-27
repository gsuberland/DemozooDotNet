using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    class ReleaserNick
    {
        public string Name { get; private set; }

        public string Abbreviation { get; private set; }

        [DeserializeAs(Name = "is_primary_nick")]
        public bool IsPrimaryNick { get; private set; }

        public List<string> Variants { get; private set; }
    }
}
