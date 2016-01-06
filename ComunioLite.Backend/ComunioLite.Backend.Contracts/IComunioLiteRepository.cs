using System.Collections.Generic;
using ComunioLite.Backend.Entities;

namespace ComunioLite.Backend.Contracts
{
    public interface IComunioLiteRepository
    {
        IEnumerable<Player> GetPlayersInMarket();
    }
}