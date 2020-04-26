namespace P03_FootballBetting.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class ColorConfiguration
        : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .HasKey(c => c.ColorId);

            builder
                .HasMany(c => c.PrimaryKitTeams)
                .WithOne(t => t.PrimaryKitColor)
                .HasForeignKey(c => c.PrimaryKitColorId);

            builder
                .HasMany(c => c.SecondaryKitTeams)
                .WithOne(t => t.SecondaryKitColor)
                .HasForeignKey(c => c.SecondaryKitColorId);
        }
    }
}
