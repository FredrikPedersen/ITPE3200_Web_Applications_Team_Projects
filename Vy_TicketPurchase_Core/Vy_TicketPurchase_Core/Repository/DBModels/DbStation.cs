using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DbStation
    {
        [Key] 
        public int Id { get; set; }
        public string StationName { get; set; }
        public virtual DbTrainLine TrainLine { get; set; }
    }
}