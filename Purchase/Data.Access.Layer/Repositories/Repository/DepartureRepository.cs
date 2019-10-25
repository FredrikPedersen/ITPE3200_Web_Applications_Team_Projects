using System;
using System.Collections.Generic;
using System.Linq;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories
{
    public class DepartureRepository : IDepartureRepository
    {
        private readonly DatabaseContext _databaseContext;

        public DepartureRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public RepositoryModelDepartures GetDepartureByID(int id)
        {
            return DbtoServiceDeparture(_databaseContext.Departures.FirstOrDefault(d => d.Id == id));
        }

        public RepositoryModelDepartures DbtoServiceDeparture(DbDepartures departure)
        {
            return new RepositoryModelDepartures()
            {
                Id = departure.Id,
                departureTime = departure.departureTime
            };
        }

        public List<RepositoryModelDepartures> GetAllDepartures()
        {
            return _databaseContext.Departures.Select(d => new RepositoryModelDepartures()
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

        public bool UpdateDeparture(int id, RepositoryModelDepartures departure)
        {
            DbDepartures departures = _databaseContext.Departures.Find(id);
            departures.departureTime = departure.departureTime;
            _databaseContext.Departures.Update(departures);
            _databaseContext.SaveChanges();
            return true;
        }

        public bool AddDeparture(RepositoryModelDepartures departure)
        {
            DbDepartures dbDeparture = new DbDepartures()
            {
                departureTime = departure.departureTime
            };
            
            _databaseContext.Departures.Add(dbDeparture);
            _databaseContext.SaveChanges();
            return true;
        }

        public bool DeleteDeparture(int id)
        {
            DbDepartures departure = _databaseContext.Departures.FirstOrDefault(d => d.Id == id);
            _databaseContext.Departures.Remove(departure);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}