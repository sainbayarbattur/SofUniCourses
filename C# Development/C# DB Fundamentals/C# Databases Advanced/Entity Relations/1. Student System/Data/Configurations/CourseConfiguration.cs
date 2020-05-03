namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course
                .HasKey(c => c.CourseId);

            course
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

            course
                .Property(c => c.Description)
                .IsUnicode(false);

            course
                .HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            course
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);
        }
    }
}
