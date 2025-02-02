namespace ReservationApp.Models
{
    
    public enum Sport
    {
    Football,
    Tennis,
    Basketball,
    Volleyball
    }

    public class Court
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public Sport Sport { get; set; }
        public decimal PricePerHour { get; set; }
        public bool IsAvailable { get; set; }
    }

}
