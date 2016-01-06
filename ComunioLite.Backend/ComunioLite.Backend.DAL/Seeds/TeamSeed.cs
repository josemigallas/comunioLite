using ComunioLite.Backend.DAL.SeedEntities;

namespace ComunioLite.Backend.DAL.Seeds
{
    public class TeamSeed
    {
        public static void GenerateSeedDataForTeam(ComunioLiteContext context)
        {
            foreach (var team in TeamSeedEntities.GetEntities())
            {
                context.Teams.Add(team);
            }
        }
    }
}