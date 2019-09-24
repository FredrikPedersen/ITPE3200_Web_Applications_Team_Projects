﻿namespace Vy_TicketPurchase.Models.DomainModels
{
    public class DomainRoute
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string StopLocation { get; set; }
        public double Price { get; set; }
        public int TravelTimeMinutes { get; set; }
    }
}