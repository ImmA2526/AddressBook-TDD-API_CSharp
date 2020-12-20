using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AddressBook
{
    class FileReadWrite
    {
        public static string path = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\AddressBook\AddressBook\SaveContact_Csv.Csv";
        public static void WriteDetail_TextFile(List<PersonalDetail> data)
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
                using (StreamWriter stremRiter = File.AppendText(path))
                {
                    stremRiter.WriteLine("FName,LName,City,State,Zip,PhoneNumber");
                    foreach (PersonalDetail ReadDetail in data)
                    {
                        stremRiter.WriteLine(ReadDetail.firstName + "," + ReadDetail.lastName + "," + ReadDetail.city + "," + ReadDetail.state + "," + ReadDetail.zip + "," + ReadDetail.phoneNumber);
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
                string[] csvData = File.ReadAllLines(path);
                foreach (string data in csvData)
                {
                    string[] csv = data.Split(",");
                    foreach (string sdata in csv)
                    {
                        Console.Write(sdata +" ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("File Not Availibe");
            }
        }
    }
}
