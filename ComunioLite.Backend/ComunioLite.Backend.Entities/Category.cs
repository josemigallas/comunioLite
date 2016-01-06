using System.Collections.Generic;

namespace ComunioLite.Backend.Entities
{
    public class Category
    {
        // Primary Key
        public int Id { get; set; }

        // Navigation Properties
        public ICollection<Player> Players { get; set; }

        // Properties
        public string Name { get; set; }
    }
}