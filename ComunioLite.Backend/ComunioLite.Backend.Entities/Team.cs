using System.Collections.Generic;

namespace ComunioLite.Backend.Entities
{
    public class Team
    {
        // Primary Key, Foreign Key
        public int ManagerId { get; set; }

        // Navigation Properties
        public Manager Manager { get; set; }
        public ICollection<Player> Players { get; set; }

        // Properties
        public string Name { get; set; }
    }
}