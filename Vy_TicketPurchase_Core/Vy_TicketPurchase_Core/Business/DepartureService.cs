using System;
using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business
{
    public class DepartureService : IDepartureService
    {
        public readonly DatabaseContext _databaseContext;

        public DepartureService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public List<DbDepartures> GetAllDepartures()
        {
            return _databaseContext.Departures.Select(t => new DbDepartures
            {
                Id = t.Id,
                departureTime = t.departureTime
            }).ToList();
        }

        public List<DbDepartures> GetDeparturesLater(string departureTime)
        {
            DateTime date1 = Convert.ToDateTime(departureTime);
            List<DbDepartures> departures = GetAllDepartures();
            List<DbDepartures> returnlist = new List<DbDepartures>();

            foreach (DbDepartures departure in departures)
            {
                DateTime date2 = Convert.ToDateTime(departure.departureTime);
                if (date2 >= date1)
                {
                    returnlist.Add(departure);
                }
            }
            return returnlist;
        }
    }
}