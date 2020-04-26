using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=TEDDY\SQLEXPRESS02;Database=StudentSystem;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.StudentModelCreating(modelBuilder);

            this.CourseModelCreating(modelBuilder);

            this.StudentCourseModelCreating(modelBuilder);

            this.ResourceModelCreating(modelBuilder);

            this.HomeworkModelCreating(modelBuilder);
        }

        public void StudentModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(h => h.Student);

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasMaxLength(10)
                .IsRequired(false);

            modelBuilder.Entity<Student>()
                .Property(s => s.Birthday)
                .IsRequired(false);
        }

        public void CourseModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

            modelBuilder.Entity<Course>()
                .HasMany(s => s.Resources)
                .WithOne(r => r.Course);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(h => h.Course);
        }

        public void StudentCourseModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.CourseId, sc.StudentId });
        }

        public void ResourceModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasKey(r => r.CourseId);

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);

            modelBuilder.Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);
        }

        public void HomeworkModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>()
                .HasKey(h => h.HomeworkId);

            modelBuilder.Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(s => s.HomeworkId);

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(s => s.CourseId);
        }
    }
}


//using System;
//using System.Linq;
//using System.Reflection;
//using System.Collections.Generic;

//using NUnit.Framework;

//using P01_StudentSystem.Data.Models;

//[TestFixture]
//public class Test_002
//{
//    [Test]
//    public void ValidateStudentAndCourseEntities()
//    {
//        //Get assembly from the most important model
//        var assembly = typeof(Student).Assembly;

//        var modelNames = new string[]
//        {
//            "Student", "Course", "StudentCourse", "Homework", "Resource"
//        };

//        var types = new Dictionary<string, Type>();
//        foreach (string name in modelNames)
//        {
//            types[name] = GetModelType(assembly, name);
//        }

//        //Check Student
//        AssertPropertyIsOfType(types["Student"], "StudentId", typeof(int));
//        AssertPropertyIsOfType(types["Student"], "Name", typeof(string));
//        AssertPropertyIsOfType(types["Student"], "PhoneNumber", typeof(string));
//        AssertPropertyIsOfType(types["Student"], "RegisteredOn", typeof(DateTime));
//        AssertPropertyIsOfType(types["Student"], "Birthday", typeof(DateTime?));

//        AssertCollectionIsOfType(types["Student"], "CourseEnrollments", GetCollectionType(types["StudentCourse"]));
//        AssertCollectionIsOfType(types["Student"], "HomeworkSubmissions", GetCollectionType(types["Homework"]));

//        //Check Course
//        AssertPropertyIsOfType(types["Course"], "CourseId", typeof(int));
//        AssertPropertyIsOfType(types["Course"], "Name", typeof(string));
//        AssertPropertyIsOfType(types["Course"], "Description", typeof(string));
//        AssertPropertyIsOfType(types["Course"], "StartDate", typeof(DateTime));
//        AssertPropertyIsOfType(types["Course"], "EndDate", typeof(DateTime));
//        AssertPropertyIsOfType(types["Course"], "Price", typeof(decimal));

//        AssertCollectionIsOfType(types["Course"], "StudentsEnrolled", GetCollectionType(types["StudentCourse"]));
//        AssertCollectionIsOfType(types["Course"], "Resources", GetCollectionType(types["Resource"]));
//        AssertCollectionIsOfType(types["Course"], "HomeworkSubmissions", GetCollectionType(types["Homework"]));
//    }

//    public static PropertyInfo GetPropertyByName(Type type, string propName)
//    {
//        var properties = type.GetProperties();

//        var firstOrDefault = properties.FirstOrDefault(p => p.Name == propName);
//        return firstOrDefault;
//    }

//    public static void AssertPropertyIsOfType(Type type, string propertyName, Type expectedType)
//    {
//        var property = GetPropertyByName(type, propertyName);
//        Assert.IsNotNull(property, $"{type.Name}.{propertyName} property not found.");

//        var errorMessage = string.Format("{0} property is not {1}!", property.Name, expectedType);
//        Assert.That(property.PropertyType, Is.EqualTo(expectedType), errorMessage);
//    }

//    public static void AssertCollectionIsOfType(Type type, string propertyName, Type collectionType)
//    {
//        var ordersProperty = GetPropertyByName(type, propertyName);

//        var errorMessage = string.Format("{0} property does not exist!", propertyName);

//        Assert.IsNotNull(ordersProperty, errorMessage);

//        Assert.That(collectionType.IsAssignableFrom(ordersProperty.PropertyType));
//    }

//    public static Type GetModelType(Assembly assembly, string modelName)
//    {
//        var modelType = assembly.GetTypes()
//            .Where(t => t.Name == modelName)
//            .FirstOrDefault();

//        Assert.IsNotNull(modelType, $"{modelName} model not found!");

//        return modelType;
//    }

//    public static Type GetCollectionType(Type modelType)
//    {
//        var collectionType = typeof(ICollection<>).MakeGenericType(modelType);
//        return collectionType;
//    }
//}