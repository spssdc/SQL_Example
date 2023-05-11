using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Runtime.Versioning;

namespace SQL_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database SQL!");
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var connection = new SqliteConnection("Data Source = " + path + "\\dbase.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "drop table if exists Student;";
            command.CommandText += "CREATE TABLE Student(ID INTEGER, First TEXT, Last TEXT, Year TEXT, PRIMARY KEY(ID));";
            command.CommandText += "INSERT INTO Student VALUES (1,'Bob','Smith','L8');";
            command.CommandText += "INSERT INTO Student VALUES (2,'Bill','Jones','U8');";
            connection.Close();

            Console.WriteLine("Enter year to locate: ");
            string year = Console.ReadLine();

            connection.Open();
            using (connection)
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText =
                    @"
                        SELECT First,Last
                        FROM Student
                        WHERE Year = $year
                    ";
                command.Parameters.AddWithValue("$year", year);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fname = reader.GetString(0);
                        var lname = reader.GetString(1);
                        Console.WriteLine(fname + " " + lname);
                    }
                }
            }
            connection.Close();
        }
    }
}