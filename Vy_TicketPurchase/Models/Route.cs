using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vy_TicketPurchase.Models
{
    public class Route
    {
        public int id { get; set; }
        public String startlocation { get; set; }
        public String stoplocation { get; set; }
        public double price { get; set; }
        public int travelTimeMinutes { get; set; }
    }
}