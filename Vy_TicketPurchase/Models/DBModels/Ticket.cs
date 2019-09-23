using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vy_TicketPurchase.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public Route route { get; set; }

        public Customer customer { get; set; }
        public String time { get; set; }

    }
}