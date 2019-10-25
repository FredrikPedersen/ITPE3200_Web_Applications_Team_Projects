using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.DBModels;

namespace Model.RepositoryModels
{
    public class RepositoryModelTrainLine
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public List<DbStation> Stations { get; set; }
    }
}