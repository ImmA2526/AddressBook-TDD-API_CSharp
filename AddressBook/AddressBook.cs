using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    /// <summary>
    /// U1. Create Contact Person List.
    /// </summary>
    class AddressBok
    {
        List<PersonalDetail> DetailList;
        public AddressBok()
        {
            this.DetailList = new List<PersonalDetail>();
        }
        /// <summary>
        /// U2. Add Contact in Contact Book
        /// </summary>
        public void AddContact()
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
            PersonalDetail Person = new PersonalDetail(FirstName, LastName, City, State, Zip, PhoneNumber);
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
                   AddContact();
                    DetailList.Remove(Contact);
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

        public void DisplayContact()
        {
            foreach (PersonalDetail Contact in DetailList)
            {
                Console.WriteLine("\nFirstName: " + Contact.firstName + "\nLastName: " + Contact.lastName + "\nCity: " + Contact.city + "\nState: " + Contact.state + "\nZip Code: " + Contact.zip + "\nMobileNumber: " + Contact.phoneNumber);
            }
        }
    }
}
