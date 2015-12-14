using System.Collections.Generic;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL.SeedEntities
{
    public class TeamSeedEntities
    {
        private static readonly List<Team> Teams = new List<Team>
        {
            new Team
            {
                Name = "Market",
                ManagerId = 0,
            }
        };

        public static IEnumerable<Team> GetEntities()
        {
            return Teams;
        }
    }
}