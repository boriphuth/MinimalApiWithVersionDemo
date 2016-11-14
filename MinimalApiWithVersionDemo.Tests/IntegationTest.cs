using System.Collections.Generic;
using Microsoft.Owin.Hosting;
using MinimalApiWithVersionDemo.Models;
using NUnit.Framework;

namespace MinimalApiWithVersionDemo.Tests
{
    [TestFixture]
    public class IntegationTest
    {
        [Test]
        public void WebApiVersion1Test()
        {
            const string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                var response = RestHelper.Get(baseAddress, "Person");
                var personList = RestHelper.GetResponseObjectResult<List<Person>>(response);
                Assert.IsNotNull(personList);
                Assert.AreEqual(4,personList.Count);
            }
        }

        [Test]
        public void WebApiVersion2Test()
        {
            const string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                var response = RestHelper.Get(baseAddress, "V2/Person");
                var personList = RestHelper.GetResponseObjectResult<List<PersonV2>>(response);
                Assert.IsNotNull(personList);
                Assert.AreEqual(4, personList.Count);
            }
        }
    }
}
