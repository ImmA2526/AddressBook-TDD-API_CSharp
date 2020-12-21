using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace AddressBook
{
    class FileReadWrite
    {
        public static string Csvpath = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\AddressBook\AddressBook\Files\SaveContact_Csv.Csv";
        public static string Textpath = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\AddressBook\AddressBook\Files\SavedContact.txt";
        public static string Jsonpath = @"C:\Users\imran\Desktop\BRDLB_WORK\DOT_NET\AddressBook\AddressBook\Files\SavedContact_Json.json";

        /// <summary>
        ///UC 13 Writes the detail text file.
        /// </summary>
        /// <param name="data">The data.</param>
        public static void WriteDetail_TextFile(List<PersonalDetail> data)
        {
            if (File.Exists(Textpath))
            {
                File.WriteAllText(Textpath, string.Empty);
                using (StreamWriter stremRiter = File.AppendText(Textpath))
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
            if (File.Exists(Textpath))
            {
                using (StreamReader stremRider = File.OpenText(Textpath))
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
            if (File.Exists(Csvpath))
            {
                File.WriteAllText(Csvpath, string.Empty);
                using (StreamWriter stremRiter = File.AppendText(Csvpath))
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
            if (File.Exists(Csvpath))
            {
                string[] csvData = File.ReadAllLines(Csvpath);
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

        /// <summary>
        /// UC15. Read and write Json File.
        /// </summary>

        public static void writeJSONFile(List<PersonalDetail> JsonData)
        {
            if (File.Exists(Jsonpath))
            {
                JsonSerializer jsonserial = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(Jsonpath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonserial.Serialize(writer, JsonData);
                }
                Console.WriteLine("Contact Stored in json");
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
        }
        public static void readJSONFile()
        {
            if (File.Exists(Jsonpath))
            {
                IList<PersonalDetail> readJson = JsonConvert.DeserializeObject<IList<PersonalDetail>>(File.ReadAllText(Jsonpath));
                foreach (PersonalDetail readJsonFile in readJson)
                {
                    readJsonFile.Display();
                }
            }
            else
            {
                Console.WriteLine("No File Exist..");
            }
        } 
    }
} 
