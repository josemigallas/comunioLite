using System.Collections.Generic;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL.SeedEntities
{
    public class ManagerSeedEntities
    {
        private static readonly List<Manager> Managers = new List<Manager>
        {
            new Manager
            {
                Id = 0,
                Name = "Computer",
            }
        };

        public static IEnumerable<Manager> GetEntities()
        {
            return Managers;
        }
    }
}