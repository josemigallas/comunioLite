using System.Collections.Generic;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL.SeedEntities
{
    public static class CategorySeedEntities
    {
        private static readonly List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = 0,
                Name = "forward",
            },
            new Category
            {
                Id = 1,
                Name = "midfielder",
            },
            new Category
            {
                Id = 2,
                Name = "defender",
            },
            new Category
            {
                Id = 3,
                Name = "goalkeeper",
            }
        };

        public static IEnumerable<Category> GetEntities()
        {
            return Categories;
        }
    }
}