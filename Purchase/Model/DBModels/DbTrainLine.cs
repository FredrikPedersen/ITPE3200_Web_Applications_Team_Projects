using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DBModels
{
    [TrackChanges]
    public class DbTrainLine
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public List<DbStation> Stations { get; set; }
    }
}