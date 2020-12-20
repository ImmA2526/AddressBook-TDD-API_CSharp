using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AddressBook
{
    class FileReadWrite
    {
        public static string path = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\AddressBook\AddressBook\SavedContact.txt";
        public static void WriteDetail_TextFile(List<PersonalDetail> data)
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
                using (StreamWriter stremRiter = File.AppendText(path))
                {
                    stremRiter.WriteLine("FName\tLName\tCity\tState\tZip\tPhoneNumber");
                    foreach (PersonalDetail ReadDetail in data)
                    {
                        stremRiter.WriteLine(ReadDetail.firstName + "\t" + ReadDetail.lastName + "\t" + ReadDetail.city + "\t" + ReadDetail.state + "\t" + ReadDetail.zip + "\t" + ReadDetail.phoneNumber);
                    }
                    stremRiter.Close();
                }
            }
            else
            {
                Console.WriteLine("File Not Availible...");
            }
        }

        public static void readFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader stremRider = File.OpenText(path))
                {
                    string data = "";
                    while ((data = stremRider.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                }
            }
            else
            {
                Console.WriteLine("File Not Availibe");
            }
        }
    }
}
