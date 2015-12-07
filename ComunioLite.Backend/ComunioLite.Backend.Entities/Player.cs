namespace ComunioLite.Backend.Entities
{
    public class Player
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Keys
        public int? TeamId { get; set; }
        public int CategoryId { get; set; }

        // Navigation Properties
        public Team Team { get; set; }
        public Category Category { get; set; }

        // Properties
        public string Name { get; set; }
        public float Price { get; set; }
    }
}