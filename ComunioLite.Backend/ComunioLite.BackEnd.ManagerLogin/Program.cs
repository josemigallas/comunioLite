using System;
using System.Collections.Generic;
using System.Linq;
using ComunioLite.Backend.DAL;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.ManagerLogin
{
    public class Program
    {
        private static ComunioLiteRepository _repository;
        private static IList<Manager> _managers;
        private static string _playerName;

        public static void Main(string[] args)
        {
            _repository = new ComunioLiteRepository(new ComunioLiteContext());

            using (_repository)
            {
                LoginInterfaceInit();
            }
        }

        private static void LoginInterfaceInit()
        {
            _managers = _repository.GetManagers() as IList<Manager>;

            ClearAndPrintHeader();

            Console.Write("Enter your name: ");
            _playerName = Console.ReadLine();

            if (PlayerNameNotExist())
            {
                AskToCreateNewManager();
            }
        }

        private static void ClearAndPrintHeader()
        {
            Console.Clear();
            Console.WriteLine("¡Welcome to ComunioLite!");
            Console.WriteLine();

            PrintManagersTable();
        }

        private static void AskToCreateNewManager()
        {
            ClearAndPrintHeader();
            Console.Write($"There is no manager with name \"{_playerName}\". ¿Create a new one <y/n>? ");
            var c = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (c)
            {
                case 'y':
                    CreateNewManagerAndTeam();
                    break;
                case 'n':
                    LoginInterfaceInit();
                    break;
                default:
                    AskToCreateNewManager();
                    break;
            }
        }

        private static void CreateNewManagerAndTeam()
        {
            ClearAndPrintHeader();
            Console.Write($"Enter a team name for {_playerName}: ");
            var teamName = Console.ReadLine();

            var team = new Team
            {
                Name = teamName
            };

            var manager = new Manager
            {
                Name = _playerName,
                Team = team,
                Money = Constants.Constants.StartingMoney
            };

            _repository.AddManager(manager);

            Console.Clear();
            Console.WriteLine("New Manager Added!");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            LoginInterfaceInit();
        }

        private static bool PlayerNameNotExist()
        {
            return _managers.All(m => !m.Name.Equals(_playerName));
        }

        private static void PrintManagersTable()
        {
            Console.WriteLine($"{"Manager",-Constants.Constants.ManagerNameMaxLength}{"Team",-Constants.Constants.TeamNameMaxLength}Money");
            Console.WriteLine();

            foreach (var manager in _managers.Where(m => m.Id != Constants.Constants.ComputerId))
            {
                Console.WriteLine(
                    $"{manager.Name,-Constants.Constants.ManagerNameMaxLength}{manager.Team.Name,-Constants.Constants.TeamNameMaxLength}{manager.Money}");
            }

            Console.WriteLine();
        }
    }
}