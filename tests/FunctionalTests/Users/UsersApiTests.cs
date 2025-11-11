using System.Net;
using System.Net.Http.Json;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FunctionalTests.Users
{
    // Fábrica específica para iniciar Users.Api
    public class TestApiFactory : WebApplicationFactory<global::Users.Api.Program>
    {
    }

    [Collection("Users")]
    public class UsersApiTests : IClassFixture<TestApiFactory>
    {
        private readonly HttpClient _client;

        public UsersApiTests(TestApiFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetUsers_ShouldReturnOk()
        {
            var response = await _client.GetAsync("/api/User/search?page=0&size=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
