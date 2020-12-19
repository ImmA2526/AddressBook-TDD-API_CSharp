using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class PersonalDetail
    {
        public string firstName;
        public string lastName;
        public string city;
        public string state;
        public string zip;
        public string phoneNumber;
        
        public PersonalDetail(string firstName,string lastName,string city,string state,string zip,string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
        }

        public void Display()
        {
            Console.WriteLine("\nFirstName: "+firstName+"\nLastName: "+lastName+"\nCity: "+city+"\nState: "+state+"\nZip Code: "+zip+"\nMobileNumber: "+phoneNumber);
        }
    }
}
