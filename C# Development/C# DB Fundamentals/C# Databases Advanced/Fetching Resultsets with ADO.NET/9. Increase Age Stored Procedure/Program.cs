using System;
using System.Data.SqlClient;
using System.Linq;

namespace _9._Increase_Age_Stored_Procedure
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            var ids = Console.ReadLine().Split().Select(int.Parse).ToList();

            using (connection)
            {
                foreach (var id in ids)
                {
                    var sqlCommand = new SqlCommand($"usp_GetOlder @MinionId = {id}", connection);

                    sqlCommand.ExecuteNonQuery();
                }

                var reader = new SqlCommand($"SELECT Name, Age FROM Minions WHERE Id IN ({string.Join(", ", ids)})", connection).ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
                }
            }
        }
    }
}
