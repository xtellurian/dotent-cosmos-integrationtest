using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace test
{
    [Collection(nameof(IntegrationCollection))]
    public class UnitTest1  //: IClassFixture<WebApplicationFactory<src.Startup>>
    {
        private readonly WebApplicationFactory<src.Startup> _factory;

        public UnitTest1(WebApplicationFactory<src.Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]

        public async Task Test1(int count)
        {
            Console.WriteLine($"Test Number {count}");

            var client = _factory.CreateClient();

            var res = await client.GetAsync("api/model");
            res.EnsureSuccessStatusCode();
            var id = await res.Content.ReadAsStringAsync();
            var delete = await client.DeleteAsync($"api/model?id={id}");
            delete.EnsureSuccessStatusCode();
        }
    }
}
