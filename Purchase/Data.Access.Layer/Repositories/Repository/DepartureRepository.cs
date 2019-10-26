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

        public RepositoryModelDepartures GetDepartureById(int id)
        {
            return DbToServiceDeparture(_databaseContext.Departures.FirstOrDefault(d => d.Id == id));
        }

        public RepositoryModelDepartures DbToServiceDeparture(DbDepartures departure)
        {
            return new RepositoryModelDepartures()
            {
                Id = departure.Id,
                DepartureTime = departure.DepartureTime
            };
        }

        public List<RepositoryModelDepartures> GetAllDepartures()
        {
            return _databaseContext.Departures.Select(d => new RepositoryModelDepartures()
            {
                Id = d.Id,
                DepartureTime = d.DepartureTime
            }).ToList();
        }

        public List<DbDepartures> GetAllDeparturesDB()
        {
            return _databaseContext.Departures.Select(t => new DbDepartures
            {
                Id = t.Id,
                DepartureTime = t.DepartureTime
            }).ToList();
        }

        public List<DbDepartures> GetDeparturesLater(string departureTime)
        {
            var departureTimeSplit = departureTime.Split(':');
            int[] departureTimeValues =
                {Convert.ToInt32(departureTimeSplit[0]), Convert.ToInt32(departureTimeSplit[1])};

            var departures = GetAllDeparturesDB();
            var departuresAfter = new List<DbDepartures>();

            foreach (var departure in departures)
            {
                String[] dbDepartureSplit = departure.DepartureTime.Split(':');
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

            var sortedDepartures = departuresAfter.OrderBy(d => d.DepartureTime).ToList();
            return sortedDepartures;
        }

        public bool UpdateDeparture(int id, RepositoryModelDepartures departure)
        {
            var departures = _databaseContext.Departures.Find(id);
            departures.DepartureTime = departure.DepartureTime;

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
                DepartureTime = departure.DepartureTime
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