using System.Data.Entity.ModelConfiguration;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL.ModelConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");

            Property(c => c.Name).HasMaxLength(20);
        }
    }
}