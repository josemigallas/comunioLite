using System;
using System.Collections.Generic;
using System.Linq;
using ComunioLite.Backend.Contracts;
using ComunioLite.Backend.Entities;
using static Constants.Constants;

namespace ComunioLite.Backend.DAL
{
    public class ComunioLiteRepository : IComunioLiteRepository, IDisposable
    {
        private readonly ComunioLiteContext _dbContext;

        public ComunioLiteRepository(ComunioLiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Player> GetPlayersInMarket()
        {
            return GetPlayersByTeam(ComputerId);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IEnumerable<Player> GetPlayersByTeam(int teamId)
        {
            return _dbContext
                .Players
                .Include(TableCategory)
                .Where(p => p.TeamId == teamId)
                .OrderByDescending(p => p.Price)
                .ToList();
        }

        public IEnumerable<Manager> GetManagers()
        {
            return _dbContext
                .Managers
                .Include(TableTeam)
                .ToList();
        }

        public Manager GetManagerById(int id)
        {
            return _dbContext
                .Managers
                .Include(TableTeam)
                .First(m => m.Id == id);
        }

        public void AddManager(Manager manager)
        {
            _dbContext.Teams.Add(manager.Team);
            _dbContext.Managers.Add(manager);
            _dbContext.SaveChanges();
        }

        public void SellPlayerToManager(int playerId, Manager buyer)
        {
            var player = _dbContext
                .Players
                .Include(TableTeam)
                .First(p => p.Id == playerId);

            var seller = GetManagerById(player.Team.ManagerId);

            seller.Money += player.Price;
            buyer.Money -= player.Price;

            player.TeamId = buyer.Team.ManagerId;

            _dbContext.SaveChanges();
        }

        public void SellPlayerToMarket(int playerId)
        {
            var computer = GetManagerById(ComputerId);
            SellPlayerToManager(playerId, computer);
        }

        public void UpdatePrices()
        {
            var random = new Random();

            _dbContext
                .Players
                .ToList()
                .ForEach(p => p.Price += 10000*random.Next(-5, 5));

            _dbContext.SaveChanges();
        }

        public Player GetPlayerById(int playerId)
        {
            return _dbContext
                .Players
                .First(p => p.Id == playerId);
        }
    }
}