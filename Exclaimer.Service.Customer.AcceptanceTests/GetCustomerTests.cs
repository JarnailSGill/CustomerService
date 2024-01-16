using Exclaimer.Service.Customer.AcceptanceTests.Fixtures;
using Exclaimer.Service.Customer.AcceptanceTests.Helpers;
using Exclaimer.Service.Customer.AcceptanceTests.Response;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.AcceptanceTests
{
    [Collection("Test Collection")]
    public class GetCustomerTests
    {
        private HttpClientFixture _httpClientFixture;
        public GetCustomerTests()
        {
            _httpClientFixture = new HttpClientFixture();
        }

        [Fact]
        public async Task ValidPersonId_Should_Return_Ok_With_ID()
        {
            var person = PersonHelper.CreateValidPersonRequest();

            var createPersonRequest = new RestRequest("api/Customer", Method.Post).AddJsonBody(person);
            var createPersonresponse = await _httpClientFixture.Client.ExecuteAsync(createPersonRequest);

            var userID = createPersonresponse.Content;
            var request = new RestRequest($"api/Customer/?id={userID}");
            var response = await _httpClientFixture.Client.ExecuteAsync(request);

            var personResponse = JsonConvert.DeserializeObject<PersonResponseDTO>(response.Content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(person.FirstName, personResponse.FirstName);
            Assert.Equal(person.LastName, personResponse.LastName);
            Assert.Equal(person.DateOfBirth, personResponse.DateOfBirth);
        }

        [Fact]
        public async Task InValidPersonID_Should_Return_NotFound()
        {
            var request = new RestRequest($"api/Customer/?id={123}");
            var response = await _httpClientFixture.Client.ExecuteAsync(request);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task InValidPersonID_Should_Return_Invalid()
        {
            var request = new RestRequest($"api/Customer/?id=");
            var response = await _httpClientFixture.Client.ExecuteAsync(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
