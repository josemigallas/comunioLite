using System;
using System.Collections.Generic;
using System.Linq;
using ComunioLite.Backend.DAL;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.Backend.Market
{
    public class Program
    {
        private static ComunioLiteRepository _repository;
        private static Manager _manager;

        private static void Main(string[] args)
        {
            _repository = new ComunioLiteRepository(new ComunioLiteContext());
            _manager = _repository.GetManagerById(Convert.ToInt32(args[0]));

            using (_repository)
            {
                InitMarket();
            }
        }

        private static void InitMarket()
        {
            Console.Clear();

            PrintManagerDashboard();
            PrintMarket();
            PrintOptionSelection();

            ReadKeyAndHandleOption();
        }

        private static void PrintManagerDashboard()
        {
            Console.WriteLine($"Manager: {_manager.Name}\nMoney: {_manager.Money}");
            PrintManagerTeam();
        }

        private static void PrintManagerTeam()
        {
            Console.WriteLine($"--------------- Team: {_manager.Team.Name} ---------------");
            var players = _repository
                .GetPlayersByTeam(_manager.Team.ManagerId);

            PrintPlayerTable(players);
        }

        private static void PrintMarket()
        {
            Console.WriteLine("--------------- Market ---------------");
            var players = _repository
                .GetPlayersInMarket()
                .OrderByDescending(p => p.Price);

            PrintPlayerTable(players);
        }

        private static void PrintPlayerTable(IEnumerable<Player> players)
        {
            Console.WriteLine(
                $"{"Id",-5}" +
                $"{"Player",-PlayerNameMaxLength}" +
                $"{"Category",-CategoryNameMaxLength}" +
                $"{"Price",15}"
                );
            Console.WriteLine();

            foreach (var player in players)
            {
                Console.WriteLine(
                    $"{player.Id,-5}" +
                    $"{player.Name,-PlayerNameMaxLength}" +
                    $"{player.Category.Name,-CategoryNameMaxLength}" +
                    $"{player.Price.ToString("F0"),15}"
                    );
            }
            Console.WriteLine();
        }

        private static void PrintOptionSelection()
        {
            string[] options =
            {
                "w: Wait",
                "b: Buy",
                "s: Sell",
                "q: Quit",
            };

            Console.WriteLine(
                $"{options[0],-12}" +
                $"{options[1],-12}" +
                $"{options[2],-12}" +
                $"{options[3],-12}"
                );
            Console.Write("What do you want to do? ");
        }

        private static void ReadKeyAndHandleOption()
        {
            var optionSelected = Console.ReadKey().KeyChar;
            switch (optionSelected)
            {
                case 'w':
                    WaitTurn();
                    break;

                case 's':
                    Console.WriteLine();
                    ReadPlayerIdAndTrySell();
                    break;

                case 'b':
                    Console.WriteLine();
                    ReadPlayerIdAndHandleBuyIfSpaceInTeam();
                    break;

                case 'q':
                    Console.WriteLine();
                    break;

                default:
                    ReadKeyAndHandleOption();
                    break;
            }
        }

        private static void WaitTurn()
        {
            UpdatePrices();
            InitMarket();
        }

        private static void UpdatePrices()
        {
            _repository.UpdatePrices();
        }

        private static void ReadPlayerIdAndTrySell()
        {
            Console.Write("Enter the player id you'd like to sell: ");
            var playerId = Convert.ToInt32(Console.ReadLine());

            if (ManagerHasPlayer(playerId))
            {
                PerformSelling(playerId);
            }
            else
            {
                ReadPlayerIdAndTrySell();
            }
        }

        private static void PerformSelling(int playerId)
        {
            UpdatePrices();
            SellPlayer(playerId);
            InitMarket();
        }

        private static bool ManagerHasPlayer(int playerId)
        {
            return _repository
                .GetPlayersByTeam(_manager.Team.ManagerId)
                .Any(p => p.Id == playerId);
        }

        private static void SellPlayer(int playerId)
        {
            _repository.SellPlayerToMarket(playerId);
        }

        private static void ReadPlayerIdAndHandleBuyIfSpaceInTeam()
        {
            if (IsTeamFull())
            {
                Console.WriteLine("Your team is already full, sell any player before buying another one.");
                Console.ReadKey();
                InitMarket();
            }
            else
            {
                ReadPlayerIdFromConsoleAndTryBuy();
            }
        }

        private static void ReadPlayerIdFromConsoleAndTryBuy()
        {
            Console.Write("Enter the player id you'd like to buy: ");
            var playerIdString = Console.ReadLine();
            var playerId = Convert.ToInt32(playerIdString);

            if (MarketHasPlayer(playerId))
            {
                PerformBuyingIfEnoughMoney(playerId);
            }
            else
            {
                ReadPlayerIdAndHandleBuyIfSpaceInTeam();
            }
        }

        private static bool IsTeamFull()
        {
            return _repository.GetPlayersByTeam(_manager.Id).Count() == TeamMaxSize;
        }

        private static void PerformBuyingIfEnoughMoney(int playerId)
        {
            var player = _repository.GetPlayerById(playerId);
            if (_manager.Money >= player.Price)
            {
                PerformBuying(playerId);
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.ReadKey();
                InitMarket();
            }
        }

        private static void PerformBuying(int playerId)
        {
            UpdatePrices();
            BuyPlayer(playerId);
            InitMarket();
        }

        private static bool MarketHasPlayer(int playerId)
        {
            return _repository
                .GetPlayersInMarket()
                .Any(p => p.Id == playerId);
        }

        private static void BuyPlayer(int playerId)
        {
            _repository.SellPlayerToManager(playerId, _manager);
        }
    }
}