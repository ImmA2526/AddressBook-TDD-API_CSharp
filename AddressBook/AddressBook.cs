using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBok
    {
        List<PersonalDetail> DetailList;
        public AddressBok()
        {
            this.DetailList = new List<PersonalDetail>();
        }

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
            Person.Display();
        }
    }
}
