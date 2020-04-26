namespace P03_FootballBetting.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration
         : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasKey(p => p.PlayerId);

            builder
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId);

            builder
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);
        }
    }
}
