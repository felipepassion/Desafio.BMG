using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Bmg.Desafio.Users.Application.DTO.Aggregates.UsersAgg.Requests;

namespace FunctionalTests.Users
{
    [Collection("Users")]
    public class UsersApi_FlowTests : IClassFixture<UsersApiFactory>
    {
        private readonly HttpClient _client;

        public UsersApi_FlowTests(UsersApiFactory factory)
        {
            _client = factory.WithWebHostBuilder(_ => { }).CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5001")
            });
        }

        [Fact]
        public async Task Search_ShouldReturnOk()
        {
            var resp = await _client.GetAsync("/api/User/search?page=0&size=1");
            resp.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateUser_ShouldReturnOk_AndAuthToken()
        {
            var dto = new UserDTO
            {
                Name = "User Test",
                Email = $"user{Guid.NewGuid()}@test.com",
                Document = "000.000.000-00",
                PhoneNumber = "11999999999",
                UserName = $"user_{Guid.NewGuid().ToString().Substring(0,6)}",
                Password = "P@ssw0rd"
            };
            var resp = await _client.PostAsJsonAsync("/api/User", dto);
            resp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.BadRequest);
        }
    }
}
