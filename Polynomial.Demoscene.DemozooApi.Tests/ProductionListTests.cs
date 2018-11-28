using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Polynomial.Demoscene.DemozooApi;
using Polynomial.Demoscene.DemozooApi.Model;
using Polynomial.Demoscene.DemozooApi.Tests;

namespace Polynomial.Demoscene.DemozooApi.Tests
{
    public class ProductionListTests
    {
        private readonly ITestOutputHelper output;

        public ProductionListTests(ITestOutputHelper output)
        {
            this.output = output;
            ApiCache.Output = output;

            ApiCache.Add(1, () => DemozooApi.GetProductions(1));
            ApiCache.Add(2, () => DemozooApi.GetProductions(2));
            ApiCache.Add(69696969, () => DemozooApi.GetProductions(69696969));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProductionList_Fetch(long id)
        {
            Assert.NotNull(ApiCache.Get<ListResults<Production>>(id));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProductionList_Length(long id)
        {
            var results = ApiCache.Get<ListResults<Production>>(id);
            Assert.True(results.Count > 0, "Result count was zero.");
            Assert.NotEmpty(results.Results);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProductionList_FirstResult(long id)
        {
            var results = ApiCache.Get<ListResults<Production>>(id);
            var firstResult = results.Results.FirstOrDefault();
            Assert.NotNull(firstResult);
            Assert.True(firstResult.ID != 0, "First result was 0");
        }

        [Fact]
        public void TestProductionList_PageNotFound()
        {
            Assert.Throws<ApiDataNotFoundException>(() =>
            {
                var results = ApiCache.Get<ListResults<Production>>(69696969);
            });
        }
    }
}
