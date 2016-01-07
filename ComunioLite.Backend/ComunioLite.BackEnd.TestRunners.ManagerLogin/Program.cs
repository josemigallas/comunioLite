﻿using System;
using System.Collections.Generic;
using System.Linq;
using ComunioLite.Backend.DAL;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.BackEnd.TestRunners.ManagerLogin
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

            Console.Clear();
            Console.WriteLine("¡Welcome to ComunioLite!");
            Console.WriteLine();

            PrintManagersTable();

            Console.Write("Enter your name: ");
            _playerName = Console.ReadLine();

            if (PlayerNameNotExist())
            {
                AskToCreateNewManager();
            }
        }

        private static void AskToCreateNewManager()
        {
            Console.Write("There is no manager with that name. ¿Create a new one <y/n>? ");
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
            Console.Write("Enter the name of your new team: ");
            var teamName = Console.ReadLine();

            var team = new Team
            {
                Name = teamName
            };

            var manager = new Manager
            {
                Name = _playerName,
                Team = team,
                Money = StartingMoney
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
            Console.WriteLine("Manager\t\tTeam");
            Console.WriteLine();

            foreach (var manager in _managers.Where(m => m.Id != ComputerId))
            {
                Console.WriteLine($"{manager.Name}\t\t{manager.Team.Name}");
            }

            Console.WriteLine();
        }
    }
}