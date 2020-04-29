namespace _7._Print_All_Minion_Names
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class Program
    {
        static List<int> editedIds = new List<int>();

        public static void Main()
        {
            var connection = new SqlConnection("Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            var minionsIds = new List<int>();

            using (connection)
            {
                var sqlCommandGivaAllIds = new SqlCommand("SELECT Id FROM Minions", connection);

                var reader = sqlCommandGivaAllIds.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        minionsIds.Add((int)reader["Id"]);
                    }
                }

                EditIds(minionsIds);

                Console.WriteLine(string.Join(" ", editedIds));

                for (int i = 0; i < editedIds.Count; i++)
                {
                    var sqlCommandNameIdConnection = new SqlCommand($"SELECT Name FROM Minions WHERE Id = {editedIds[i]}", connection);

                    var nameReader = sqlCommandNameIdConnection.ExecuteReader();

                    if (nameReader.Read()) Console.WriteLine(nameReader["Name"]);

                    nameReader.Close();
                }
            }
        }

        private static int EditIds(List<int> ids)
        {
            for (int i = 1; i < ids.Count; i++)
            {
                editedIds.Add(i);

                editedIds.Add(ids.Count - i);

                if (editedIds.Count == 10)
                {
                    return 0;
                }
            }

            return 0;
        }
    }
}
