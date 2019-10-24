using System.ComponentModel.DataAnnotations;

namespace Purchase.Model.RepositoryModels
{
    public class RepositoryModelPassengerType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }
        
        public double PriceMultiplier { get; set; }
    }
}