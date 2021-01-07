using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AddressBookTester
{
    public class addressWork
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phoneNumber { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public DateTime Date { get; set; }
    }

    [TestClass]
    public class Api_Tester
    {
        RestClient client;
        public object JsonConvertor { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }
        private IRestResponse GetEmployeeList()
        {
            RestRequest request = new RestRequest("/AddressBook", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        /// <summary>
        /// UC 22 Retrive Record 
        /// </summary>

        [TestMethod]
        public void OnCalling_GetApi_ReturnList()
        {
            IRestResponse response = GetEmployeeList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<addressWork> dataResponse = JsonConvert.DeserializeObject<List<addressWork>>(response.Content);
            Assert.AreEqual(5, dataResponse.Count);

            foreach (addressWork e in dataResponse)
            {
                Console.WriteLine("\nFirstName: " + e.firstName + "\nLastName: " + e.lastName + "\nCity: " + e.city + "\nState: " + e.state + "\nZip Code: " + e.zip + "\nMobileNumber: " + e.phoneNumber);
            }
        }
    }
}
