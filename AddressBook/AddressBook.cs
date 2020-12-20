using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AddressBook
{
    /// <summary>
    /// U5. Create Contact Person List with Multiple Contact.
    /// </summary>
    public class AddressBok
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

        /// <summary>
        /// UC7. Check Duplicate Name
        /// </summary>
        /// <param name="FirstName"></param>
        /// <returns></returns>
        public bool DuplicateName(string FirstName)
        {
            bool duplicate = false;
            foreach (PersonalDetail Name in DetailList)
            {
                if (Name.firstName.Equals(FirstName))
                {
                    duplicate = true;
                    Console.WriteLine($"{FirstName} is Alredy Present");
                    break;
                }
            }
            return duplicate;
        }

        /// <summary>
        /// U8-Uc9 & 10. Search Contact By City or State 
        /// </summary>
        /// <param name="place"></param>
        public void SearchPersonByCity(string place)
        {
            List<string> State = new List<string>();
            bool exits = IsPlaceExist(place);
            int city_StateCount = 0;
            if (exits)
            {
                foreach (PersonalDetail user in DetailList.FindAll(x => x.city.Equals(place)).ToList())
                {
                    string Name = user.firstName + " " + user.lastName;
                    State.Add(Name);
                    city_StateCount++;
                }
                foreach (PersonalDetail user in DetailList.FindAll(x => x.state.Equals(place)).ToList())
                {
                    string Name = user.firstName + " " + user.lastName;
                    State.Add(Name);
                    city_StateCount++;
                }
                ///UC 10 Count By Place
                Console.WriteLine($"Person Form Place: {place} : {city_StateCount}");
                foreach (string val in State)
                {
                    Console.WriteLine("Name Of The Person :"+val);
                }
            }
            else
            {
                Console.WriteLine("Contect not Found ");
            }
        }
        public bool IsPlaceExist(string place)
        {
            if (this.DetailList.Any(e => e.city == place) || this.DetailList.Any(e => e.state == place))
                return true;
            else
                return false;
        }
/
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
