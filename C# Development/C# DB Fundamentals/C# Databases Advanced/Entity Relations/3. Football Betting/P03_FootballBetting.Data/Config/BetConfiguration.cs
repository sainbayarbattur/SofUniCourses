namespace P03_FootballBetting.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BetConfiguration
        : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder
                .HasKey(b => b.BetId);

            builder
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

            builder
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);
        }
    }
}
