using System;

namespace AddressBook
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Welcome To Address Book*********");
            AddressBok Book = new AddressBok();
            while (true)
            {
                Console.Write("1.Add Contact\n2.EditContact\n3.Display\n4.Delete\n0.Exit\nEnter Choice To Proceed:  ");
                int Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        Book.AddContact();
                        break;
                    case 2:
                        Console.Write("Enter FirstName To Edit: ");
                        string Name = Console.ReadLine();
                        Book.EditContact(Name);
                        break;
                    case 3:
                        Book.DisplayContact();
                        break;
                    case 4:
                        Console.Write("Enter FirstName To Delete: ");
                        string DelName = Console.ReadLine();
                        Book.DeletContact(DelName);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
