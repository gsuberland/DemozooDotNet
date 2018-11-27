using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    class Member
    {
        [DeserializeAs(Name = "member")]
        public ReleaserReference MemberReference { get; private set; }

        public bool IsCurrent { get; private set; }
    }
}
