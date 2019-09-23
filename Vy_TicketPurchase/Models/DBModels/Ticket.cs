﻿using System;

namespace Vy_TicketPurchase.Models.DBModels
{
    public class Ticket
    {
        public int Id { get; set; }
        public Route Route { get; set; }

        public Customer Customer { get; set; }
        public String Time { get; set; }

    }
}