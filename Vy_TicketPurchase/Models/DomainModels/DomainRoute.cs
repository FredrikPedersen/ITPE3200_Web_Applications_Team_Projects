﻿namespace Vy_TicketPurchase.Models.DomainModels
{
    public class DomainRoute
    {
        public int Id { get; set; }
        public string Startlocation { get; set; }
        public string Stoplocation { get; set; }
        public double Price { get; set; }
        public int TravelTimeMinutes { get; set; }
    }
}