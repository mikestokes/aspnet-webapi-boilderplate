using System;
using System.Net;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Net.Http;
using WebApi.Boilderplate.Controllers;
using Newtonsoft.Json;

namespace WebApi.Boilderplate.Tests.IntegrationTests
{
    [TestClass]
    public class ControllerTests : BaseHttpTest
    {
        // NOTE: This provides a nice HTTP self host to perform integration tests.

        // TODO: Enhance / add as required.
        
        [TestMethod]
        public void Test_ShouldReturn_OK()
        {
            var routesToTest = new List<string>
            {
                "api/v1/bom/111"
            };

            for (var i = 0; i < routesToTest.Count; i++)
            {
                var uri = BaseAddress + routesToTest[i];

                var response = Client.GetAsync(uri).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [TestMethod]
        public void Test_ShouldReturn_OKAndBody_When_PostingDetailsObject()
        {
            var routesToTest = new List<string>
            {
                "api/v1/bom"
            };

            var detail = new
            {
                firstName = "Mike",
                lastName = "Stokes"
            };
                        
            for (var i = 0; i < routesToTest.Count; i ++)
            {
                var uri = BaseAddress + routesToTest[i];

                var response = Client.PostAsJsonAsync<dynamic>(uri, detail).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

                var content = response.Content.ReadAsStringAsync().Result;

                var deserialized = JsonConvert.DeserializeObject<BOMController.DetailModel>(content);

                Assert.IsNotNull(deserialized);
                Assert.AreEqual(deserialized.FirstName, "Mike");
                Assert.AreEqual(deserialized.LastName, "Stokes");
            }
        }

    }
}
