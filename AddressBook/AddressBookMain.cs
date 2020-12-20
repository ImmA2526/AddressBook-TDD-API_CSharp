using System;
using System.Collections.Generic;
namespace AddressBook
{
    class AddressBookMain
    {
        public static Dictionary<string, AddressBok> DetailDict = new Dictionary<string, AddressBok>();

        public static void Main(string[] args)
        {
            Console.WriteLine("*********Welcome To Address Book*********");
            //Dictionary<string, AddressBok> DetailDict = new Dictionary<string, AddressBok>();
            bool Flag = true;
            Console.Write("\nHow many Address Book U Want :");
            int numberofBook = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= numberofBook; i++)
            {
                Console.Write("Enter Name of Book: " + i + ":");
                string BookName = Console.ReadLine();
                bool Check = DuplicateBook(BookName);
                if (Check)
                {
                    Console.WriteLine("Please Enter Bookname Again");
                    BookName=Console.ReadLine();
                }
                AddressBok addBookName = new AddressBok();
                DetailDict.Add(BookName, addBookName);
            }
                    
            Console.WriteLine("Created AddressBokk");
            foreach (string K in DetailDict.Keys)
            {
                Console.WriteLine(K);
            }

            while (Flag)
            {
                Console.WriteLine("1.Add Contact\n2.EditContact\n3.Display\n4.Delete\n5.SearchBy City_State & Show Count\n6.Sort Detail\n0.Exit\nEnter Choice To Proceed:  ");
                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        Console.WriteLine("Enter Address Book Name where you want to Add");
                        string addContact = Console.ReadLine();
                        if (DetailDict.ContainsKey(addContact))
                        {
                            Console.WriteLine("How many Contact u want to Add: ");
                            int numberofContact = Convert.ToInt32(Console.ReadLine());
                            for (int a = 1; a <=numberofContact; a++)
                            {
                                AddContact1(DetailDict[addContact]);
                            }
                            DetailDict[addContact].DisplayContact();
                        }
                        else
                        {
                            Console.WriteLine("No Address Book Present..");
                        }
                        break;
                    case 2:
                        Console.Write("Address Book Name To Edit Contact ");
                        string EditName = Console.ReadLine();
                        if (DetailDict.ContainsKey(EditName))
                        {
                            Console.Write("Enter Name You want To Edit");
                            string NameEdit = Console.ReadLine();
                            DetailDict[EditName].EditContact(NameEdit);
                            DetailDict[EditName].DisplayContact();
                        }
                        else
                        {
                            Console.WriteLine("No Detail");
                        }
                        break;
                    case 3:
                        Console.Write("Enter Address Book To Display: ");
                        string DisplayContactinBook = Console.ReadLine();
                        DetailDict[DisplayContactinBook].DisplayContact();
                        break;
                    case 4:
                        Console.Write("Enter AddressBook Name To Delete Contact: ");
                        string DelName = Console.ReadLine();
                        if (DetailDict.ContainsKey(DelName))
                        {
                            Console.Write("Enter First Name To Delete Contact: ");
                            string NametoDelete=Console.ReadLine();
                            DetailDict[DelName].DeletContact(NametoDelete);
                            DetailDict[DelName].DisplayContact();
                        }
                        else
                        {
                            Console.Write("No Detail");
                        }
                        break;
                    case 5:
                        Console.Write("Enter City or State : ");
                        string SearchCity = Console.ReadLine();
                        foreach (var City in DetailDict.Keys)
                        {
                            Console.WriteLine("You Entered: " + SearchCity);
                            DetailDict[City].SearchPersonByCity(SearchCity);
                        }
                        break;
                    case 6:
                        Console.Write("Enter AddressBook Name For Sorting: ");
                        string sortBookName = Console.ReadLine();
                        DetailDict[sortBookName].SortByAlphabetically();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /// <summary>
        /// UC6. Add Multiple AddressBook
        /// </summary>
        /// <param name="Add">The add.</param>
        public static void AddContact1(AddressBok AddBookName)
        {
            Console.Write("Enter First Name: ");
            string FirstName = Console.ReadLine();
            bool dup = AddBookName.DuplicateName(FirstName);
            if (dup)
            {
                Console.Write("Enter First Name: ");
                FirstName = Console.ReadLine();
            }
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
            AddBookName.AddContact(FirstName, LastName,  City, State, Zip, PhoneNumber);
        }

        /// <summary>
        /// U7 Check Duplicate Book NAme
        /// </summary>
        /// <param name="bookname"></param>
        /// <returns></returns>
        public static bool DuplicateBook(string bookname)
        {
            bool Check = false;
            foreach (var Address in DetailDict)
            {
                if (DetailDict.ContainsKey(bookname))
                {
                    Check = true;
                    Console.WriteLine($"{bookname} Address Book Alrdy Present..");
                    break;
                }
            }
            return Check;
        }
    }
}
