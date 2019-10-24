using System.Collections.Generic;
using Model.RepositoryModels;

namespace Model.ViewModels
{
    public class IndexModel
    {
        public List<RepositoryModelStation> Stations { get; set; }
        public RepositoryModelTicket Ticket { get; set; }

        public RepositoryModelUser User { get; set; }


    }
}