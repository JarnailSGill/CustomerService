using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exclaimer.Service.Customer.AcceptanceTests.Fixtures
{
    public class HttpClientFixture : IDisposable
    {
        public HttpClientFixture()
        {
            Client = new RestClient(new Uri("http://localhost:8080/"));
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        public RestClient Client { get; private set; }
    }

}
