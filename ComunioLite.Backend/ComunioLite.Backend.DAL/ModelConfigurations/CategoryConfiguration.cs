using System.Data.Entity.ModelConfiguration;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.Backend.DAL.ModelConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable(TableCategory);

            Property(c => c.Name).HasMaxLength(CategoryNameMaxLength);
        }
    }
}