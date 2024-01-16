using Exclaimer.Service.Customer.AcceptanceTests.Fixtures;
using Exclaimer.Service.Customer.AcceptanceTests.Helpers;
using Exclaimer.Service.Customer.AcceptanceTests.Response;
using Exclaimer.Service.Customer.Application.DTOs;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Exclaimer.Service.Customer.AcceptanceTests
{
    [Collection("Test Collection")]
    public class CreateCustomerTests
    {
        private HttpClientFixture _httpClientFixture;

        public CreateCustomerTests()
        {
            _httpClientFixture = new HttpClientFixture();
        }

        [Fact]
        public async Task ValidPersonRequest_Should_Return_Ok_With_ID()
        {
            var person = PersonHelper.CreateValidPersonRequest();
            var request = new RestRequest("api/Customer", Method.Post).AddJsonBody(person);
            var response = await _httpClientFixture.Client.ExecuteAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
        }

        [Fact]
        public async Task InvalidEmail_Should_Return_BadRequest()
        {
            var person = PersonHelper.CreateValidPersonRequest();

            // Set an invalid email address
            person.Email = "invalid-email";

            var request = new RestRequest("api/Customer", Method.Post).AddJsonBody(person);
            var response = await _httpClientFixture.Client.ExecuteAsync(request);

            var validationErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(response.Content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.NotNull(response.Content);
            Assert.Equal(validationErrorResponse.Errors[0].Message, "Invalid email format.");
        }

        [Fact]
        public async Task InvalidRequest_Should_Return_Unsupported_Media_Type()
        {
            var request = new RestRequest("api/Customer", Method.Post);
            var response = await _httpClientFixture.Client.ExecuteAsync(request);

            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
            Assert.NotNull(response.Content);
        }
    }
}