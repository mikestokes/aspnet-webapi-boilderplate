using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApi.Boilderplate.Tests.IntegrationTests
{
    public class BaseHttpTest
    {
        protected const string BaseAddress = "http://localhost:9000/";

        protected IDisposable WebApi;

        protected HttpClient Client;


        [TestInitialize]
        public void Initialise()
        {
            WebApi = WebApp.Start<Startup>(BaseAddress);

            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            Client = new HttpClient(handler);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (WebApi != null)
            {
                WebApi.Dispose();
            }

            if (Client != null)
            {
                Client.Dispose();
            }
        }
    }
}