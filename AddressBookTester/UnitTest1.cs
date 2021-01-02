using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook;


namespace AddressBookTester
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Uc 16 Givens the employee payroll when retrieve then return employee payroll from data base.
        /// </summary>
        [TestMethod]
        public void AddressBookGiven_RetrieveRecord_ShouldReturnData()
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
            editModel.firstName = "Anis";
            editModel.lastName = "Shaikh";
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
    }
}
