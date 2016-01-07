using System;
using System.Collections.Generic;
using System.Linq;
using ComunioLite.Backend.DAL;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.BackEnd.TestRunners.ManagerLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repository = new ComunioLiteRepository(new ComunioLiteContext());

            using (repository)
            {
                Console.WriteLine("¡Welcome to ComunioLite!");
                Console.WriteLine();

                var managers = repository.GetManagers() as IList<Manager>;

                Console.WriteLine("Manager\t\tTeam");
                Console.WriteLine();
                foreach (var manager in managers.Where(m => m.Id != ComputerId))
                {
                    Console.WriteLine($"{manager.Name}\t\t{manager.Team.Name}");
                }

                Console.WriteLine();
                Console.Write("Enter your name: ");
                var playerName = Console.ReadLine();

                if (managers.All(m => !m.Name.Equals(playerName)))
                {
                    Console.Write("There is no manager with that name. ¿Create a new one <y/n>? ");
                    var c = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (c == 'y')
                    {
                        Console.Write("Enter the name of your new team: ");
                        var teamName = Console.ReadLine();

                        var team = new Team
                        {
                            Name = teamName
                        };

                        var manager = new Manager
                        {
                            Name = playerName,
                            Team = team,
                            Money = StartingMoney
                        };

                        repository.AddManager(manager);
                    }
                }
            }
        }
    }
}