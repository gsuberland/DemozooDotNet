using System;
using System.Collections.Generic;
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
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestFetchProductionLists(long id)
        {
            Assert.NotNull(ApiCache.Get<Production>(id));
        }
    }
}
