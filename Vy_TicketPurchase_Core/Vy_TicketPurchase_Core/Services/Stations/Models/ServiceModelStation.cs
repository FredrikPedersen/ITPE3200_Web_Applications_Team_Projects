using System.ComponentModel.DataAnnotations;
using Vy_TicketPurchase_Core.Models.DBModels;

namespace Vy_TicketPurchase_Core.Services.Stations.Models
{
    public class ServiceModelStation
    {
        [Key]
        public int Id { get; set; }
        public string StationName { get; set; }
        
        public virtual DbTrainLine TrainLine { get; set; }
    }
}