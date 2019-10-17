using System.Collections.Generic;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DbTrainLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DbStation> Stations { get; set; }
    }
}