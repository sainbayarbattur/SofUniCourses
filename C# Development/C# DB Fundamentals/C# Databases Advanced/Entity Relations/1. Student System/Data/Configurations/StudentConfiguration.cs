namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

            student
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

            student
                .Property(s => s.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            student
                .Property(s => s.Birthday)
                .IsRequired(false);

            student
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId);
        }
    }
}