using System;

namespace AddressBook
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Welcome To Address Book*********");
            AddressBok Book = new AddressBok();
            Console.Write("Enter Choice To Proceed\n1.Add Contact\n2.Exit");
            int Choice = Convert.ToInt32(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    Book.AddContact();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
