using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace _3._Minion_Names
{
    public class Program
    {
        public static void Main()
        {
            string connectionString = "Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true";

            SqlCommand queryVillainsCmd;

            SqlCommand queryMinionsCmd;

            int id = int.Parse(Console.ReadLine());

            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                string queryVillains = $"SELECT Name FROM Villains WHERE Id = {id} ";

                string queryMinions = "SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum, " +
                                        "m.Name, " +
                                        "m.Age " +
                                    "FROM MinionsVillains AS mv " +
                                    "JOIN Minions As m ON mv.MinionId = m.Id " +
                                    $"WHERE mv.VillainId = {id} " +
                                    "ORDER BY m.Name ";

                queryVillainsCmd = new SqlCommand(queryVillains, connection);

                queryMinionsCmd = new SqlCommand(queryMinions, connection);

                var reader = queryVillainsCmd.ExecuteReader();

                using (reader)
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Villain: {reader["Name"]}");
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                    }
                }

                reader = queryMinionsCmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}