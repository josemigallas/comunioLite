using System.Data.Entity.ModelConfiguration;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.Backend.DAL.ModelConfigurations
{
    public class PlayerConfiguration : EntityTypeConfiguration<Player>
    {
        public PlayerConfiguration()
        {
            ToTable(TablePlayer);

            // Many Players to One Category
            HasRequired(p => p.Category)
                .WithMany(c => c.Players)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);

            // Many Players to One Team
            HasOptional(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .WillCascadeOnDelete(false);

            Property(p => p.Name).HasMaxLength(PlayerNameMaxLength);
        }
    }
}