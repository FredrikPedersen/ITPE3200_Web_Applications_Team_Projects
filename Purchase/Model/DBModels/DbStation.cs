using System.ComponentModel.DataAnnotations;

namespace Model.DBModels
{
    public class DbStation
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage ="Stasjonsnummer må fylles ut!")]
        public int NumberOnLine { get; set; }
        [Required(ErrorMessage ="Stasjonsnavn må fylles ut!")]
        public string StationName { get; set; }
        public virtual DbTrainLine TrainLine { get; set; }
    }
}