using System;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "server=localhost;user=root;database=dogexhibition";

        using (IDbConnection db = new MySqlConnection(connectionString))
        {
            var result = db.Query("SELECT * FROM dogs");
            foreach (var row in result)
            {
                Console.WriteLine(row.name);
            }
        }
    }
}
