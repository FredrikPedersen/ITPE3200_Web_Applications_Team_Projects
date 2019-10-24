using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.ServiceModels
{
    public class ServiceModelPassengerType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
        
        public double PriceMultiplier { get; set; }
    }
}