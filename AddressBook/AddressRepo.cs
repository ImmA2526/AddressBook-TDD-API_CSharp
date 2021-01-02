﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace AddressBook
{
    public class AddressRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=True";
        SqlConnection Connection = new SqlConnection(connectionString);

        /// <summary>
        /// UC16 Check Connection
        /// </summary>
        public bool CheckConnection()
        {
            try
            {
                this.Connection.Open();
                Console.WriteLine("Connection Established");
                this.Connection.Close();
                return true;
            }

            catch (Exception e)
            {
                return false;
                Console.WriteLine(e.StackTrace);
            }

        }

        /// <summary>
        /// UC 16 Retrives the record.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int RetriveRecord()
        {
            try
            {
                AddressModel Fetch = new AddressModel();
                using (this.Connection)
                {
                    int count = 0;
                    using (SqlCommand fetch = new SqlCommand(@"Select * from AddressBook WHERE city='pune' OR state='Maha';", this.Connection))
                    {
                        this.Connection.Open();
                        using (SqlDataReader reader = fetch.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                                Fetch.firstName = reader.GetString(0);
                                Fetch.lastName = reader.GetString(1);
                                Fetch.address = reader.GetString(2);
                                Fetch.city = reader.GetString(3);
                                Fetch.state = reader.GetString(4);
                                Fetch.zip = reader.GetString(5);
                                Fetch.phoneNumber = reader.GetString(6);
                                Fetch.BookName = reader.GetString(7);
                                Fetch.BookType = reader.GetString(8);
                                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", Fetch.firstName, Fetch.lastName, Fetch.address, Fetch.city, Fetch.state, Fetch.zip, Fetch.phoneNumber, Fetch.BookName, Fetch.BookType);
                            }
                        }
                    }
                    return count;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// UC 17 Edits the name of the record using.
        /// </summary>
        /// <param name="Model">The model.</param>
        /// <exception cref="Exception"></exception>
        public bool EditRecordUsingName(AddressModel Model)
        {
            try
            {
                using (this.Connection)
                {
                    string editQuery = @"Update AddressBook set lastName= @lastName, address = @address,city = @city, state = @state, zip=@zip,phoneNumber=@phoneNumber ,BookName = @BookName, BookType = @BookType WHERE firstName = @firstName;";
                    SqlCommand CMD = new SqlCommand(editQuery, this.Connection);
                    CMD.Parameters.AddWithValue("@firstName", Model.firstName);
                    CMD.Parameters.AddWithValue("@lastName", Model.lastName);
                    CMD.Parameters.AddWithValue("@address", Model.address);
                    CMD.Parameters.AddWithValue("@city", Model.city);
                    CMD.Parameters.AddWithValue("@state", Model.state);
                    CMD.Parameters.AddWithValue("@zip", Model.zip);
                    CMD.Parameters.AddWithValue("@phoneNumber", Model.phoneNumber);
                    CMD.Parameters.AddWithValue("@BookName", Model.BookName);
                    CMD.Parameters.AddWithValue("@BookType", Model.BookType);
                    this.Connection.Open();
                    var result = CMD.ExecuteNonQuery();
                    Console.WriteLine("Updated Success......");
                    this.Connection.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
    }
}