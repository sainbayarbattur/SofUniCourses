namespace _5._Change_Town_Names_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            var connection = new SqlConnection("Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            var towns = new List<string>();

            string countryName = Console.ReadLine();

            using (connection)
            {
                var cmdu = new SqlCommand("UPDATE Towns " +
                    "SET Name = UPPER(Name) " +
                    $"WHERE CountryCode = (SELECT TOP 1 Id FROM Countries WHERE Name = '{countryName}')", connection);

                int rowsA = cmdu.ExecuteNonQuery();

                var cmdS = new SqlCommand("SELECT t.Name " +
                    "FROM Towns t " +
                    "JOIN Countries c " +
                    "ON t.CountryCode = c.Id " +
                    $"WHERE c.Name = '{countryName}'", connection);

                var reader = cmdS.ExecuteReader();

                if (rowsA == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                Console.WriteLine($"{rowsA} town names were affected. ");

                using (reader)
                {
                    while (reader.Read())
                    {
                        towns.Add(reader["Name"].ToString());
                    }

                    Console.WriteLine('[' + string.Join(", ", towns) + ']');
                }
            }
        }
    }
}
