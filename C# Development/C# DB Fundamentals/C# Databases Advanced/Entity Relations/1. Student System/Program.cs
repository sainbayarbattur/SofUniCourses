namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    using P01_StudentSystem.Data.Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new StudentSystemContext();

            db.Database.EnsureCreated();
        }
    }
}