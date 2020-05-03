namespace P01_StudentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource
                .HasKey(r => r.CourseId);

            resource
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);

            resource
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            resource
                .Property(r => r.Url)
                .IsUnicode(false);
        }
    }
}