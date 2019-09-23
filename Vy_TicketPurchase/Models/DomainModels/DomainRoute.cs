﻿namespace Vy_TicketPurchase.Models.DomainModels
{
    public class DomainRoute
    {
        public int id { get; set; }
        public string startlocation { get; set; }
        public string stoplocation { get; set; }
        public double price { get; set; }
        public int travelTimeMinutes { get; set; }
    }
}