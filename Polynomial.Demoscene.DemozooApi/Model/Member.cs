using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi
{
    class Member
    {
        [DeserializeAs(Name = "member")]
        public ReleaserReference MemberReference { get; private set; }

        public bool IsCurrent { get; private set; }
    }
}
