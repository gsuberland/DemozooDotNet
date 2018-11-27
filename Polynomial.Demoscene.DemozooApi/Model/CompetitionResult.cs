using RestSharp.Deserializers;

namespace Polynomial.Demoscene.DemozooApi.Model
{
    class CompetitionResult
    {
        public long Position { get; private set; }

        public string Ranking { get; private set; }

        public string Score { get; private set; }

        public Production Production { get; set; }
    }
}
