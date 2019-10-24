using Purchase.Model.DBModels;
using Purchase.Model.RepositoryModels;
using System.Collections.Generic;

namespace Purchase.Model.ViewModels
{
    public class AdminModel
    {
        public List<RepositoryModelStation> Stations { get; set; }
        public RepositoryModelStation Station { get; set; }
        
        public List<RepositoryModelTicket> Tickets { get; set; }
        public RepositoryModelTicket Ticket { get; set; }
        
        public List<RepositoryModelPassengerType> Types  { get; set; }
        public RepositoryModelPassengerType Type  { get; set; }
        
        public List<DbTrainLine> Lines  { get; set; }
        public DbTrainLine Line  { get; set; }
        
        public List<RepositoryModelDepartures> Departures { get; set; }
        public RepositoryModelDepartures Departure  { get; set; }
        
    }
}