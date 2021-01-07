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

        /// <summary>
        /// UC 23 Add Multiple Address
        /// </summary>
        [TestMethod]
        public void AddMultiple_Address_BY_API()
        {
            List<addressWork> addMultiple = new List<addressWork>();
            addMultiple.Add(new addressWork { firstName = "Ahtesham",lastName = "Ansari",address = "Dighi",city = "Pune",state = "Maha",zip = "413512",phoneNumber = "816372829",BookName="Friend",BookType="Friend",Date = new DateTime(2020, 01, 01) });
            addMultiple.Add(new addressWork { firstName = "Mohsin", lastName = "Ansari", address = "Dighi", city = "Pune", state = "Maha", zip = "413512", phoneNumber = "816372829", BookName = "Friend", BookType = "Friend", Date = new DateTime(2020, 01, 01) });
            addMultiple.Add(new addressWork { firstName = "Nijam", lastName = "Ansari", address = "Dighi", city = "Pune", state = "Maha", zip = "413512", phoneNumber = "816372829", BookName = "Friend", BookType = "Friend", Date = new DateTime(2020, 01, 01) });
            addMultiple.ForEach(record =>
            {
                    RestRequest request = new RestRequest("/AddressBook", Method.POST);
                    JObject jObjectBody = new JObject();
                    jObjectBody.Add("firstName", record.firstName);
                    jObjectBody.Add("lastName", record.lastName);
                    jObjectBody.Add("address", record.address);
                    jObjectBody.Add("city", record.city);
                    jObjectBody.Add("state", record.state);
                    jObjectBody.Add("zip", record.zip);
                    jObjectBody.Add("phoneNumber", record.phoneNumber);
                    jObjectBody.Add("BookName", record.BookName);
                    jObjectBody.Add("BookType", record.BookType);
                    jObjectBody.Add("Date", record.Date);
        
                    request.AddParameter("application/json", jObjectBody, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
                    addressWork dataResorce = JsonConvert.DeserializeObject<addressWork>(response.Content);

                    Assert.AreEqual(record.firstName, dataResorce.firstName);
                    Assert.AreEqual(record.lastName, dataResorce.lastName);
                    Assert.AreEqual(record.address, dataResorce.address);
                    Assert.AreEqual(record.city, dataResorce.city);
                    Assert.AreEqual(record.state, dataResorce.state);
                    Assert.AreEqual(record.zip, dataResorce.zip);
                    Assert.AreEqual(record.phoneNumber, dataResorce.phoneNumber);
                    Assert.AreEqual(record.BookName, dataResorce.BookName);
                    Assert.AreEqual(record.BookType, dataResorce.BookType);
                    Assert.AreEqual(record.Date, dataResorce.Date);
                    Console.WriteLine(response.Content);
            });
        }
    }
}
