namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class Route
    {
        public int Id { get; set; }
        public string Startlocation { get; set; }
        public string Stoplocation { get; set; }
        public double Price { get; set; }
        public int TravelTimeMinutes { get; set; }

        public override string ToString()
        {
            return Startlocation + " " + Stoplocation + " " + Price + " " + TravelTimeMinutes;
        }
    }
}