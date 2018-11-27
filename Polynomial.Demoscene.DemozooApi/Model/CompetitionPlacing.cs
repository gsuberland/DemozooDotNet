namespace Polynomial.Demoscene.DemozooApi
{
    class CompetitionPlacing
    {
        public long Position { get; private set; }
        public string Ranking { get; private set; }
        public string Score { get; private set; }
        public CompetitionReference Competition { get; private set; }
    }
}
