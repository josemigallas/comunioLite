using System.Collections.Generic;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.DAL.SeedEntities
{
    public static class PlayerSeedEntities
    {
        private static readonly List<Player> Players = new List<Player>
        {
            new Player
            {
                Name = "Messi",
                Price = 24000000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Cristiano Ronaldo",
                Price = 23070000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Neymar",
                Price = 20390000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Griezmann",
                Price = 19930000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Luis Suárez",
                Price = 18410000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Aduriz",
                Price = 15530000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Orellana",
                Price = 15020000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Benzema",
                Price = 14880000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Iago Aspas",
                Price = 13960000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Bale",
                Price = 13750000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Modric",
                Price = 13650000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Lucas Pérez",
                Price = 13580000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Iniesta",
                Price = 12530000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Konoplyanka",
                Price = 12310000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Williams",
                Price = 11600000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Ferreira Carrasco",
                Price = 11330000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Agirretxe",
                Price = 10880000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Godín",
                Price = 10770000,
                CategoryId = 3,
                TeamId = 1,
            },
            new Player
            {
                Name = "Javi Guerra",
                Price = 10760000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Sergio Busquets",
                Price = 10650000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Borja Bastón",
                Price = 10550000,
                CategoryId = 1,
                TeamId = 1,
            },
            new Player
            {
                Name = "Halilovic",
                Price = 10180000,
                CategoryId = 2,
                TeamId = 1,
            },
            new Player
            {
                Name = "Rubén Castro",
                Price = 9880000,
                CategoryId = 1,
                TeamId = 1,
            }
        };

        public static IEnumerable<Player> GetEntities()
        {
            return Players;
        }
    }
}