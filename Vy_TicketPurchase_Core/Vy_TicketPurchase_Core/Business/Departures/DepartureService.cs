using System;
using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Business.Departures.Models;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business.Departures
{
    public class DepartureService
    {
        private readonly DatabaseContext _databaseContext;

        public DepartureService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ServiceModelDepartures GetDepartureByID(int id)
        {
            return DbtoServiceDeparture(_databaseContext.Departures.FirstOrDefault(d => d.Id == id));
        }

        public ServiceModelDepartures DbtoServiceDeparture(DbDepartures departure)
        {
            return new ServiceModelDepartures()
            {
                Id = departure.Id,
                departureTime = departure.departureTime
            };
        }

        public List<ServiceModelDepartures> GetAllDepartures()
        {
            return _databaseContext.Departures.Select(d => new ServiceModelDepartures()
            {
                Id = d.Id,
                departureTime = d.departureTime
                
            }).ToList();
        }
        
        public List<DbDepartures> GetAllDeparturesDB()
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
            List<DbDepartures> departures = GetAllDeparturesDB();
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

        public bool UpdateDeparture(int id, ServiceModelDepartures departure)
        {
            DbDepartures departures = _databaseContext.Departures.Find(id);
            departures.departureTime = departure.departureTime;
            _databaseContext.Departures.Update(departures);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}