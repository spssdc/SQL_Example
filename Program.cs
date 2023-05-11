using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

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
            command.ExecuteNonQuery();
            command.CommandText = "CREATE TABLE Student(ID INTEGER, First TEXT, Last TEXT, Year TEXT, PRIMARY KEY(ID));";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Student VALUES (1,'Bob','Smith','L8');";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Student VALUES (1,'Bill','Jones','U8');";
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}