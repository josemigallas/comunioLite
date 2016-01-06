using System.Data.Entity.ModelConfiguration;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL.ModelConfigurations
{
    public class ManagerConfiguration : EntityTypeConfiguration<Manager>
    {
        public ManagerConfiguration()
        {
            ToTable("Manager");

            HasRequired(m => m.Team)
                .WithRequiredPrincipal(t => t.Manager)
                .WillCascadeOnDelete(false);

            Property(m => m.Name).HasMaxLength(50);
        }
    }
}