using ComunioLite.Backend.DAL.SeedEntities;

namespace ComunioLite.Backend.DAL.Seeds
{
    public class PlayerSeed
    {
        public static void GenerateSeedDataForPlayer(ComunioLiteContext context)
        {
            foreach (var player in PlayerSeedEntities.GetEntities())
            {
                context.Players.Add(player);
            }
        }
    }
}