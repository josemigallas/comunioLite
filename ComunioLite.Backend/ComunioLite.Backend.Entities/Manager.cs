namespace ComunioLite.Backend.Entities
{
    public class Manager
    {
        // Primary Key
        public int Id { get; set; }

        // Navigation Properties
        public Team Team { get; set; }

        // Properties
        public string Name { get; set; }
        public float Money { get; set; }
    }
}