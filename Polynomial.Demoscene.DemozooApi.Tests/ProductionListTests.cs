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
        private const long InvalidPageId = -1;

        private readonly ITestOutputHelper output;

        public ProductionListTests(ITestOutputHelper output)
        {
            this.output = output;
            ApiCache.Output = output;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProductionList_Fetch(long pageNum)
        {
            Assert.NotNull(ApiCache.Cache(pageNum, () => DemozooApi.GetProductions(pageNum)));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProductionList_Length(long pageNum)
        {
            var results = ApiCache.Cache(pageNum, () => DemozooApi.GetProductions(pageNum));
            Assert.True(results.Count > 0, "Result count was zero.");
            Assert.NotEmpty(results.Results);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProductionList_FirstResult(long pageNum)
        {
            var results = ApiCache.Cache(pageNum, () => DemozooApi.GetProductions(pageNum));
            var firstResult = results.Results.FirstOrDefault();
            Assert.NotNull(firstResult);
            Assert.True(firstResult.ID != 0, "First result had ID 0.");
        }

        [Fact]
        public void TestProductionList_PageNotFound()
        {
            Assert.Throws<ApiDataNotFoundException>(() =>
            {
                var results = DemozooApi.GetProductions(InvalidPageId);
            });
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestProductionList_NextPage(long pageNum)
        {
            var results = ApiCache.Cache(pageNum, () => DemozooApi.GetProductions(pageNum));
            Assert.NotNull(results.NextPage);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void TestProductionList_PreviousPage(long pageNum)
        {
            var results = ApiCache.Cache(pageNum, () => DemozooApi.GetProductions(pageNum));
            Assert.NotNull(results.PreviousPage);
        }

        [Fact]
        public void TestProductionList_PreviousPageOnFirstPage()
        {
            var results = ApiCache.Cache(1, () => DemozooApi.GetProductions(1));
            Assert.Null(results.PreviousPage);
        }
    }
}
