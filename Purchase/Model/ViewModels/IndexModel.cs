using Purchase.Model.ServiceModels;
using System.Collections.Generic;

namespace Purchase.Model.ViewModels
{
    public class IndexModel
    {
        public List<ServiceModelStation> Stations { get; set; }
        public ServiceModelTicket Ticket { get; set; }

        public ServiceModelUser User { get; set; }


    }
}