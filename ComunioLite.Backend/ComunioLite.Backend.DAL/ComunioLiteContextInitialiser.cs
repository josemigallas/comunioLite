using System.Data.Entity;
using ComunioLite.Backend.DAL.Seeds;

namespace ComunioLite.Backend.DAL
{
    public class ComunioLiteContextInitialiser : DropCreateDatabaseAlways<ComunioLiteContext>
    {
        protected override void Seed(ComunioLiteContext context)
        {
            CategorySeed.GenerateSeedDataForCategory(context);
            PlayerSeed.GenerateSeedDataForPlayer(context);
            ManagerSeed.GenerateSeedDataForManager(context);
            TeamSeed.GenerateSeedDataForTeam(context);

            base.Seed(context);
        }
    }
}