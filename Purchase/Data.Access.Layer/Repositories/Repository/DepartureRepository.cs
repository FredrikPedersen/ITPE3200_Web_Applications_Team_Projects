using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories
{
    public class DepartureRepository : IDepartureRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger _logger;

        public DepartureRepository(DatabaseContext databaseContext, ILogger logger)
        {
            _databaseContext = databaseContext;
            _logger = logger;
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
            _logger.LogInformation("jhgjhg");
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
            String[] departureTimeSplit = departureTime.Split(':');
            int[] departureTimeValues =
                {Convert.ToInt32(departureTimeSplit[0]), Convert.ToInt32(departureTimeSplit[1])};

            List<DbDepartures> departures = GetAllDeparturesDB();
            List<DbDepartures> departuresAfter = new List<DbDepartures>();

            foreach (DbDepartures departure in departures)
            {
                String[] dbDepartureSplit = departure.departureTime.Split(':');
                int[] dbDepartureValues = {Convert.ToInt32(dbDepartureSplit[0]), Convert.ToInt32(dbDepartureSplit[1])};

                if (dbDepartureValues[0] > departureTimeValues[0])
                {
                    departuresAfter.Add(departure);
                }
                else if (dbDepartureValues[0] == departureTimeValues[0])
                {
                    if (dbDepartureValues[1] > departureTimeValues[1])
                        departuresAfter.Add(departure);
                }
            }

            List<DbDepartures> sortedDepartures = departuresAfter.OrderBy(d => d.departureTime).ToList();
            return sortedDepartures;
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
    }
}