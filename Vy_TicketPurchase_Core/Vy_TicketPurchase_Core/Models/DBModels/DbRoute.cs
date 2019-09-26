namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DbRoute
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string StopLocation { get; set; }
        public double Price { get; set; }
        public int TravelTimeMinutes { get; set; }
    }
}