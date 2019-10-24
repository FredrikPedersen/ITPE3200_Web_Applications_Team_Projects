using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business
{
    public class DepatureServiceStub : IDepartureService
    {
        public List<DbDepartures> GetAllDepartures()
        {
            throw new NotImplementedException();
        }

        public List<DbDepartures> GetDeparturesLater(string departureTime)
        {
            throw new NotImplementedException();
        }
    }
}