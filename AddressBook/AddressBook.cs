using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AddressBook
{
    /// <summary>
    /// U5. Create Contact Person List with Multiple Contact.
    /// </summary>
    class AddressBok
    {
        List<PersonalDetail> DetailList;
        public AddressBok()
        {
            DetailList = new List<PersonalDetail>();
        }
        /// <summary>
        /// U2. Add Contact in Contact Book
        /// </summary>
        public void AddContact(string firstName, string lastName, string city, string state, string zip, string phoneNumber)
        {
            PersonalDetail Person = new PersonalDetail(firstName, lastName, city, state,  zip, phoneNumber);
            DetailList.Add(Person);
        }

        /// <summary>
        ///U3. Edits the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        public  void EditContact(string fname)
        {
            int size = DetailList.Count;
            int check = 0;
            foreach (PersonalDetail Contact in DetailList)
            {
                check++;
                if (Contact.firstName.Equals(fname))
                {
                    Console.Write("Enter First Name: ");
                    string FirstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    string LastName = Console.ReadLine();
                    Console.Write("Enter City: ");
                    string City = Console.ReadLine();
                    Console.Write("Enter State: ");
                    string State = Console.ReadLine();
                    Console.Write("Enter Zip Code: ");
                    string Zip = Console.ReadLine();
                    Console.Write("Enter Phone Number: ");
                    string PhoneNumber = Console.ReadLine();
                    DetailList.Remove(Contact);
                    AddContact(FirstName, LastName, City, State, Zip, PhoneNumber);
                    Console.WriteLine("Contact Updated Successfully...");
                    break;
                }
                else if (size == check)
                {
                    Console.WriteLine(fname + " not found in addressbook...");
                    break;
                }
            }
        }

        /// <summary>
        /// U4. Delets the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        public void DeletContact(string firstName)
        {
            int size=DetailList.Count;
            int check = 0;
            foreach (PersonalDetail Contact in DetailList)
            {
                check++;
                if (firstName.Equals(Contact.firstName))
                {
                    DetailList.Remove(Contact);
                    Console.WriteLine("Contact Deleted Succesfull...");
                    break;
                }
                else if(size==check)
                {
                    Console.WriteLine("Contact Not Found");
                }
            }
        }

        public void DisplayContact()
        {
            foreach (var Contacts in DetailList)
            {
                PersonalDetail detail = Contacts;
                Console.WriteLine("\nFirstName: " + Contacts.firstName + "\nLastName: " + Contacts.lastName + "\nCity: " + Contacts.city + "\nState: " + Contacts.state + "\nZip Code: " + Contacts.zip + "\nMobileNumber: " + Contacts.phoneNumber);
            }
        }
    }
}
