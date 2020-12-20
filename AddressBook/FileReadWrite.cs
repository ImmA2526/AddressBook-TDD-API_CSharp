using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AddressBook
{
    class FileReadWrite
    {
        public static string path = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\AddressBook\AddressBook\SaveContact_Csv.Csv";
        public static string path1 = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\AddressBook\AddressBook\SavedContact.txt";

        /// <summary>
        ///UC 13 Writes the detail text file.
        /// </summary>
        /// <param name="data">The data.</param>
        public static void WriteDetail_TextFile(List<PersonalDetail> data)
        {
            if (File.Exists(path1))
            {
                File.WriteAllText(path1, string.Empty);
                using (StreamWriter stremRiter = File.AppendText(path1))
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

        public static void textReadFile()
        {
            if (File.Exists(path1))
            {
                using (StreamReader stremRider = File.OpenText(path1))
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

        /// <summary>
        ///UC 14 Writes the detail CSV file.
        /// </summary>
        /// <param name="data">The data.</param>
        public static void WriteDetail_CsvFile(List<PersonalDetail> data)
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
                        Console.Write(sdata + " ");
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
