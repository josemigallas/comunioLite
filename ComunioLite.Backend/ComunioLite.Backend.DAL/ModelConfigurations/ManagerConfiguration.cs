using System.Data.Entity.ModelConfiguration;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.Backend.DAL.ModelConfigurations
{
    public class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            ToTable(TableManager);

            HasRequired(m => m.Team)
                .WithRequiredPrincipal(t => t.Manager)
                .WillCascadeOnDelete(false);

            Property(m => m.Name).HasMaxLength(ManagerNameMaxLength);
        }
    }
}