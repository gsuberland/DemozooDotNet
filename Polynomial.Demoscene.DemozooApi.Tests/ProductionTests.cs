using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Polynomial.Demoscene.DemozooApi;
using Polynomial.Demoscene.DemozooApi.Model;
using Polynomial.Demoscene.DemozooApi.Tests;

namespace Polynomial.Demoscene.DemozooApi.Tests.DotNetCore
{
    public class ProductionTests
    {
        private const long InvalidProductionId = -1;

        private readonly ITestOutputHelper output;

        public ProductionTests(ITestOutputHelper output)
        {
            this.output = output;
            ApiCache.Output = output;

            ApiCache.Add(1, () => DemozooApi.GetProduction(1));
            ApiCache.Add(2, () => DemozooApi.GetProduction(2));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProduction_Fetch(long id)
        {
            Assert.NotNull(ApiCache.Get<Production>(id));
        }

        [Fact]
        public void TestProduction_NotFound()
        {
            Assert.Throws<ApiDataNotFoundException>(() => 
            {
                var prod = DemozooApi.GetProduction(InvalidProductionId);
            });
        }

        [Theory]
        [InlineData(1, "Rob Is Jarig")]
        [InlineData(2, "State of the Art")]
        public void TestProduction_CorrectTitle(long id, string title)
        {
            var prod = ApiCache.Get<Production>(id);
            Assert.Equal(title, prod.Title);
        }
    }
}
