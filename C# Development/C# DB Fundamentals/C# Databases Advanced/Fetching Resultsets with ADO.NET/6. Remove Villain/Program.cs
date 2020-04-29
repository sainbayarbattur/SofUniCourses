using System;
using System.Data.SqlClient;

namespace _6._Remove_Villain
{
    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            int id = int.Parse(Console.ReadLine());

            using (connection)
            {
                var findNameSqlCommand = new SqlCommand($"SELECT TOP 1 Name FROM Villains WHERE Id = {id}", connection);

                var reader = findNameSqlCommand.ExecuteReader();

                string name = string.Empty;

                if (reader.Read()) name = reader["Name"].ToString();

                reader.Close();

                var deleteSqlCommand = new SqlCommand($"DELETE MinionsVillains WHERE VillainId = {id}", connection);

                int rows = deleteSqlCommand.ExecuteNonQuery();

                if (rows == 0)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                Console.WriteLine($"{name} was deleted.");

                deleteSqlCommand = new SqlCommand($"DELETE Villains WHERE Id = {id}", connection);

                int minionsReleased = deleteSqlCommand.ExecuteNonQuery();

                Console.WriteLine(rows);
            }
        }
    }
}
