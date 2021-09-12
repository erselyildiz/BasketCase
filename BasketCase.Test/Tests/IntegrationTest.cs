using BasketCase.Test.Contexts;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System;

namespace BasketCase.Test.Tests
{
    public class IntegrationTest
    {
        private const string ApihBasket = "/api/basket";
        private const string ApiProduct = "/api/product";

        [Theory]
        [InlineData("613ce8077d9b46580f8a5a3f", Int32.MaxValue)]
        public async Task AddProductToBasket_OutOfStock_ShouldBeNotFount(string productId, int quantity)
        {
            using var httpClient = new TestContext().TestClient;

            var response = await httpClient.PostAsync($"{ApihBasket}", new StringContent(JsonConvert.SerializeObject(new { ProductId = productId, Quantity = quantity }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("613de6456c6bf9d1b347d625", 1)]
        public async Task AddProductToBasket_NotExist_ShouldBeNotFount(string productId, int quantity)
        {
            using var httpClient = new TestContext().TestClient;

            var response = await httpClient.PostAsync($"{ApihBasket}", new StringContent(JsonConvert.SerializeObject(new { ProductId = productId, Quantity = quantity }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("613ce87aa4fd2ce91c7feadd")]
        public async Task AddProductToBasket_WithoutQuantity_ShouldBeBadRequest(string productId)
        {
            using var httpClient = new TestContext().TestClient;

            var response = await httpClient.PostAsync($"{ApihBasket}", new StringContent(JsonConvert.SerializeObject(new { ProductId = productId }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("id")]
        public async Task AddProductToBasket_WithInvalidId_ShouldBeBadRequest(string productId)
        {
            using var httpClient = new TestContext().TestClient;

            var response = await httpClient.PostAsync($"{ApihBasket}", new StringContent(JsonConvert.SerializeObject(new { ProductId = productId }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Theory]
        [InlineData("613ce94c6ff6b192e174baee", 1)]
        public async Task AddProductToBasket_ShouldBeOk(string productId, int quantity)
        {
            using var httpClient = new TestContext().TestClient;

            var response = await httpClient.PostAsync($"{ApihBasket}", new StringContent(JsonConvert.SerializeObject(new { ProductId = productId, Quantity = quantity }), Encoding.UTF8, "application/json"));

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllProduct_ShouldBeOk()
        {
            using var httpClient = new TestContext().TestClient;
            var response = await httpClient.GetAsync($"{ApiProduct}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}