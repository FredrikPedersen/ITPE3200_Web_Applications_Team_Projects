using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business
{
    internal interface IDepartureService
    {
        List<DbDepartures> GetAllDepartures();

        List<DbDepartures> GetDeparturesLater(string departureTime);
    }
}