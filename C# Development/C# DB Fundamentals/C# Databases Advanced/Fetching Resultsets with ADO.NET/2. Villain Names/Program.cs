namespace _2._Villain_Names
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            string connectionString = "Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                string sqlCommand = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  " +
                    "FROM Villains AS v" +
                    "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId" +
                    "GROUP BY v.Id, v.Name" +
                    "HAVING COUNT(mv.VillainId) > 3" +
                    "ORDER BY COUNT(mv.VillainId)";

                var cmd = new SqlCommand(sqlCommand, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                    }
                }
            }
        }
    }
}
