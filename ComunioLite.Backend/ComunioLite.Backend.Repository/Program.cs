using System;
using ComunioLite.Backend.DAL;

namespace ComunioLite.Backend.Repository
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repository = new ComunioLiteRepository(new ComunioLiteContext());

            using (repository)
            {
                foreach (var player in repository.GetPlayersInMarket())
                {
                    Console.WriteLine($"{player.Name}\t{player.Price}");
                }
            }
        }
    }
}