using System.Data.Entity;
using System.Linq;
using ComunioLite.Backend.DAL;

namespace ComunioLite.Backend.DatabaseInit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new ComunioLiteContextInitialiser());

            using (var context = new ComunioLiteContext())
            {
                context.Managers.ToList();
            }
        }
    }
}