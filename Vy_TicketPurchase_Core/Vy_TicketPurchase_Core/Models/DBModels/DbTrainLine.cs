using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vy_TicketPurchase_Core.Models.DBModels
{
    public class DbTrainLine
    {
        public int Id { get; set; }
        public List<DbStation> stations { get; set; }
        public double price { get; set; }
    }
}