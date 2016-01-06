using System.Data.Entity.ModelConfiguration;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.Backend.DAL.ModelConfigurations
{
    public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            ToTable(TableTeam);

            // One Team to One Manager
            HasKey(t => t.ManagerId);

            Property(t => t.Name).HasMaxLength(TeamNameMaxLength);
        }
    }
}