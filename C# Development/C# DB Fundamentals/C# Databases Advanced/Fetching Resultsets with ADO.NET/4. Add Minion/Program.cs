namespace _4._Add_Minion
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            try
            {
                var connection = new SqlConnection("Server=TEDDY\\SQLEXPRESS02;Database=MinionsDB;Integrated Security=true");
                connection.Open();

                string minion = Console.ReadLine();

                string minionName = minion.Split()[1];

                int age = int.Parse(minion.Split()[2]);

                string townName = minion.Split()[3];

                string villainName = Console.ReadLine().Split()[1];

                int townId = 0;

                int villianId = 0;

                using (connection)
                {
                    var sqlTown = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{townName}'", connection);

                    var sqlVillain = new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainName}'", connection);

                    using (sqlTown)
                    {
                        if (sqlTown.ExecuteScalar() == null)
                        {
                            var addTown = new SqlCommand($"INSERT INTO Towns (Name) VALUES ('{townName}')", connection);
                            addTown.ExecuteNonQuery();

                            Console.WriteLine($"Town {townName} was added to the database.");
                        }

                        townId = (int)sqlTown.ExecuteScalar();
                    }

                    using (sqlVillain)
                    {
                        if (sqlVillain.ExecuteScalar() == null)
                        {
                            var addVillians = new SqlCommand($"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('{villainName}', {4})", connection);
                            addVillians.ExecuteNonQuery();

                            Console.WriteLine($"Villain {villainName} was added to the database.");
                        }

                        villianId = (int)sqlVillain.ExecuteScalar();
                    }

                    var sqlMinions = new SqlCommand($"INSERT INTO Minions (Name, Age, TownId) VALUES ('{minionName}', {age}, {townId})", connection);
                    sqlMinions.ExecuteNonQuery();

                    int minionID = (int)new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{minionName}' ORDER BY Id DESC", connection).ExecuteScalar();

                    var sqlMinionsVillains = new SqlCommand($"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES ({minionID}, {villianId})", connection);
                    sqlMinionsVillains.ExecuteNonQuery();

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
