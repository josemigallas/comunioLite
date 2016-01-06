using System.Data.Entity.ModelConfiguration;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL.ModelConfigurations
{
    public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            ToTable("Team");

            // One Team to One Manager
            HasKey(t => t.ManagerId);

            Property(t => t.Name).HasMaxLength(50);
        }
    }
}