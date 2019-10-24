using Purchase.Model.RepositoryModels;
using System.Collections.Generic;

namespace Purchase.Model.ViewModels
{
    public class IndexModel
    {
        public List<RepositoryModelStation> Stations { get; set; }
        public RepositoryModelTicket Ticket { get; set; }

        public RepositoryModelUser User { get; set; }


    }
}