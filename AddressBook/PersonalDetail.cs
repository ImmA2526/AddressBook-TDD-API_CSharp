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
        public string address;
        public string zip;
        public long phoneNumber;
        public string email;
        
        public PersonalDetail(string firstName,string lastName,string city,string state,string address,string zip,long phoneNumber,string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.state = state;
            this.address = address;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public void Display()
        {
            Console.WriteLine("\nFirstName: "+firstName+"\nLastName: "+lastName+"\nCity: "+city+"\nState: "+state+"\nAddress: "+address+"\nZip Code: "+zip+"\nMobileNumber: "+phoneNumber);
        }
    }
}
