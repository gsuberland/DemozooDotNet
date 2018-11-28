using System;
using Xunit;

namespace Polynomial.Demoscene.DemozooApi.Tests.DotNetCore
{
    public class Productions
    {
        [Fact]
        public void TestFetchProduction()
        {
            var production = DemozooApi.GetProduction(1);
            Assert.NotNull(production);
            Assert.Equal(@"https://demozoo.org/api/v1/productions/1/", production.ApiUrl);
            Assert.Equal(@"https://demozoo.org/productions/1/", production.DemozooUrl);
            Assert.Equal(1, production.ID);
            Assert.Equal(@"Rob Is Jarig", production.Title);
            Assert.Equal(new DateTime(2000, 3, 1), production.ReleaseDate);
        }
    }
}
