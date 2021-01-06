using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook;
using System;

namespace AddressBookTester
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Uc 16 Retrive All Data.
        /// Uc 19 Retrive Data By City or State.(Refactor of UC 16)
        /// </summary>
        [TestMethod]
        public void AddressBookGiven_RetrieveRecordBy_City_State_ShouldReturnData()
        {
            int expected = 6;
            AddressRepo retriveData = new AddressRepo();
            int count = retriveData.RetriveRecord();            
            Assert.AreEqual(expected, count);
        }

        /// <summary>
        /// Uc 17 Updates the contact when first name given.
        /// </summary>
        [TestMethod]
        public void UpdateContact_WhenFirstNameGiven()
        {
            bool update = true;
            AddressRepo updateRepo = new AddressRepo();
            AddressModel updateModel = new AddressModel();

            AddressModel editModel = new AddressModel();
            editModel.lastName = "Shaikh";
            editModel.firstName = "Anis";
            editModel.address = "Dighi";
            editModel.state = "Maha";
            editModel.city = "Pune";
            editModel.zip = "123456";
            editModel.phoneNumber = "9876789876";
            editModel.BookName = "Family";
            editModel.BookType = "Family";
            bool result = updateRepo.EditRecordUsingName(editModel);
            Assert.AreEqual(update, result);
        }

        /// <summary>
        /// 18 Retrives the data when date range query given.
        /// </summary>
        [TestMethod]
        public void RetriveData_WhenDateRange_QueryGiven()
        {
            int retriveParticular = 2;
            AddressRepo retrive = new AddressRepo();
            int contactsCount = retrive.RetriveParticularRecord();
            Assert.AreEqual(retriveParticular,contactsCount);
        }

        /// <summary>
        /// UC 20 Add contact.
        /// </summary>
        
        [TestMethod]
        public void AddContact_WhenAddQueryGiven()
        {
            bool Add = true;
            AddressRepo addContact = new AddressRepo();
            //AddressModel updateModel = new AddressModel();

            AddressModel AddModel = new AddressModel();
            AddModel.firstName = "Anis";
            AddModel.lastName = "Shaikh";
            AddModel.address = "Dighi";
            AddModel.state = "Maha";
            AddModel.city = "Pune";
            AddModel.zip = "123456";
            AddModel.phoneNumber = "9876789876";
            AddModel.BookName = "Family";
            AddModel.BookType = "Family";
            AddModel.Date=new System.DateTime(2010,11,02);
            bool result = addContact.AddRecordIN_DB(AddModel);
            Assert.AreEqual(Add, result);
        }

        /// <summary>
        /// UC 21 Adds the contact when add query given.
        /// </summary>
        [TestMethod]
        public void AddContact_WhenAddQueryGiven_WithExecutionTime()
        {
            AddressRepo addContact = new AddressRepo();
            AddressModel AddModel = new AddressModel()
            {
                firstName = "Nijam",
                lastName = "Shaikh",
                address = "Pune",
                state = "Maha",
                city = "Dighi",
                zip = "876677",
                phoneNumber = "9996789876",
                BookName = "Friend",
                BookType = "Family",
                Date = new DateTime(2020, 11, 02)
            };
            DateTime startTime = DateTime.Now;
            addContact.AddRecordIN_DB(AddModel);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration taken for insertion is {0}", (stopTime - startTime));
        }
    }
}
