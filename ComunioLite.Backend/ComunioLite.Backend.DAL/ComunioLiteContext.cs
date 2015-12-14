using System.Data.Entity;
using ComunioLite.Backend.DAL.ModelConfigurations;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL
{
    public class ComunioLiteContext : DbContext
    {
        public ComunioLiteContext() : this("ComunioLite")
        {
        }

        public ComunioLiteContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ManagerConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());
            modelBuilder.Configurations.Add(new PlayerConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}