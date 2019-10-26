using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class DepartureRepositoryStub : IDepartureRepository
    {
        public DepartureRepositoryStub()
        {
        }

        public RepositoryModelDepartures DbToServiceDeparture(DbDepartures departure)
        {
            if (departure == null) return null;
            return new RepositoryModelDepartures()
            {
                Id = departure.Id,
                DepartureTime = departure.DepartureTime
            };
        }

        public bool AddDeparture(RepositoryModelDepartures departure)
        {
            return true;
        }

        public bool DeleteDeparture(int id)
        {
            return true;
        }

        public List<RepositoryModelDepartures> GetAllDepartures()
        {
            var departureList = new List<RepositoryModelDepartures>();
            var repositoryModelDeparture = new RepositoryModelDepartures()
            {
                Id = 1,
                DepartureTime = "12:00"
            };
            departureList.Add(repositoryModelDeparture);
            departureList.Add(repositoryModelDeparture);
            departureList.Add(repositoryModelDeparture);
            return departureList;
        }

        public List<DbDepartures> GetAllDeparturesDB()
        {
            var departureList = new List<DbDepartures>();
            var dbDepartures = new DbDepartures()
            {
                Id = 1,
                DepartureTime = "12:00"
            };
            departureList.Add(dbDepartures);
            departureList.Add(dbDepartures);
            departureList.Add(dbDepartures);
            return departureList;
        }

        public RepositoryModelDepartures GetDepartureById(int id)
        {
            if (id == 0) return null;
            var repositoryModelDeparture = new RepositoryModelDepartures()
            {
                Id = id,
                DepartureTime = "12:00"
            };

            return repositoryModelDeparture;
        }

        public List<DbDepartures> GetDeparturesLater(string departureTime)
        {
            if (departureTime.Equals("")) return null;
            var dateTime = DateTime.ParseExact(departureTime, "HH:mm", null);
            var departureList = new List<DbDepartures>();
            var dbDepartures = new DbDepartures()
            {
                Id = 1,
                DepartureTime = "16:00"
            };
            if (DateTime.ParseExact(dbDepartures.DepartureTime, "HH:mm", null) <= dateTime) return null;
            departureList.Add(dbDepartures);
            departureList.Add(dbDepartures);
            departureList.Add(dbDepartures);
            return departureList;

        }

        public bool UpdateDeparture(int id, RepositoryModelDepartures departure)
        {
            if (id == 0) return false;
            return departure != null;
        }
    }
}