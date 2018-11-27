using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    public class Releaser
    {
        [DeserializeAs(Name = "demozoo_url")]
        public string DemozooUrl { get; private set; }

        public long ID { get; private set; }

        public string Name { get; private set; }

        public bool IsGroup { get; private set; }

        public List<ReleaserNick> Nicks { get; private set; }

        [DeserializeAs(Name = "member_of")]
        public List<Member> MemberOf { get; private set; }

        public List<Member> Members { get; private set; }

        [DeserializeAs(Name = "external_links")]
        public List<ExternalLink> ExternalLinks { get; private set; }
    }
}
