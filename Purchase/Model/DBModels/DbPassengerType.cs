using System.ComponentModel.DataAnnotations;

namespace Model.DBModels
{
    [TrackChanges]
    public class DbPassengerType
    {
        [Key] 
        public int Id { get; set; }
        public string Type { get; set; }
        public double PriceMultiplier { get; set; }
    }
}