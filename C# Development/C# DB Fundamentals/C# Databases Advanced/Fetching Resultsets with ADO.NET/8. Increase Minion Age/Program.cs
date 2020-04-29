using System;
using System.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace _8._Increase_Minion_Age
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            var result = new List<string>();

            var ids = Console.ReadLine().Split().Select(int.Parse).ToList();

            using (connection)
            {
                foreach (var id in ids)
                {
                    var sqlCommandSelect = new SqlCommand($"SELECT Name, Age FROM Minions WHERE Id = {id}", connection);

                    var reader = sqlCommandSelect.ExecuteReader();

                    if (reader.Read())
                    {
                        string titleCasedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(reader["Name"].ToString());

                        var sqlCommandUpdate = new SqlCommand($"UPDATE Minions SET Name = '{titleCasedName}', Age += 1 WHERE Id = {id}", connection);

                        reader.Close();

                        sqlCommandUpdate.ExecuteNonQuery();
                    }
                }

                var sqlCommandSelectN = new SqlCommand($"SELECT Name, Age FROM Minions", connection);

                var readerN = sqlCommandSelectN.ExecuteReader();

                while (readerN.Read())
                {
                    Console.WriteLine(readerN["Name"] + " "  + readerN["Age"].ToString());
                }
            }
        }
    }
}
