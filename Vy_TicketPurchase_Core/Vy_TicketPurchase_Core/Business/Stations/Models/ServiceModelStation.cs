using System.ComponentModel.DataAnnotations;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business.Stations.Models
{
    public class ServiceModelStation
    {
        [Key]
        public int Id { get; set; }
        
        public int NumberOnLine { get; set; }
        public string StationName { get; set; }
        
        public virtual DbTrainLine TrainLine { get; set; }
    }
}