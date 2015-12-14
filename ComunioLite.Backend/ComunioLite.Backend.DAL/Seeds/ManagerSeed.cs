using ComunioLite.Backend.DAL.SeedEntities;

namespace ComunioLite.Backend.DAL.Seeds
{
    public class ManagerSeed
    {
        public static void GenerateSeedDataForManager(ComunioLiteContext context)
        {
            foreach (var manager in ManagerSeedEntities.GetEntities())
            {
                context.Managers.Add(manager);
            }
        }
    }
}