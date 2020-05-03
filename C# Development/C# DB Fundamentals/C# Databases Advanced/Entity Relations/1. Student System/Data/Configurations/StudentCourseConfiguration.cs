namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> studentCourse)
        {
            studentCourse
                .HasKey(sc => new { sc.CourseId, sc.StudentId });

            studentCourse
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

            studentCourse
                .HasOne(sc => sc.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}