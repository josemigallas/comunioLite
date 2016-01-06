using ComunioLite.Backend.DAL.SeedEntities;

namespace ComunioLite.Backend.DAL.Seeds
{
    public class CategorySeed
    {
        public static void GenerateSeedDataForCategory(ComunioLiteContext context)
        {
            foreach (var category in CategorySeedEntities.GetEntities())
            {
                context.Categories.Add(category);
            }
        }
    }
}