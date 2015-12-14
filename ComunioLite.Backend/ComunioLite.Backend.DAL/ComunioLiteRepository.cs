using System;
using System.Collections.Generic;
using System.Linq;
using ComunioLite.Backend.Contracts;
using ComunioLite.Backend.Entities;

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
            return _dbContext.Players
                .Where(p => p.Team.Name.Equals("Market"))
                .ToList();
        }

        public void Dispose()
        {
        }
    }
}