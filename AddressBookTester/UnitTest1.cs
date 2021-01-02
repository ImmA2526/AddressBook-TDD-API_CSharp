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
    }
}
