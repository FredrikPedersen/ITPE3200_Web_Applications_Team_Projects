using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DbTrainLine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DbStation> Stations { get; set; }
    }
}