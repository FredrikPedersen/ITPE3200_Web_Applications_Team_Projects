using System;
using System.Collections.Generic;
using System.Linq;
using Data.Access.Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.RepositoryModels;
using Utilities.Logging;

namespace Data.Access.Layer.Repositories.Repository
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

            var sortedDepartures = departuresAfter.OrderBy(d => d.departureTime).ToList();
            return sortedDepartures;
        }

        public bool UpdateDeparture(int id, RepositoryModelDepartures departure)
        {
            var departures = _databaseContext.Departures.Find(id);
            departures.departureTime = departure.departureTime;

            try
            {
                _databaseContext.Departures.Update(departures);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                ErrorLogger.LogError(ex);
                return false;
            }
        }

        public bool AddDeparture(RepositoryModelDepartures departure)
        {
            var dbDeparture = new DbDepartures()
            {
                departureTime = departure.departureTime
            };

            _databaseContext.Departures.Add(dbDeparture);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}