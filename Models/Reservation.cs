namespace ReservationApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public string? UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Court? Court { get; set; }
    }
}
