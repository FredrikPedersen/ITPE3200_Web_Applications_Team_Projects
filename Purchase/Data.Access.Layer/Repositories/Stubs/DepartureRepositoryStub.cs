using System;
using System.Collections.Generic;
using System.Text;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class DepartureRepositoryStub : IDepartureRepository
    {
        public DepartureRepositoryStub()
        {
        }

        public RepositoryModelDepartures DbtoServiceDeparture(DbDepartures departure)
        {
            if (departure == null) return null;
            return new RepositoryModelDepartures()
            {
                Id = departure.Id,
                departureTime = departure.departureTime
            };
        }

        public bool AddDeparture(RepositoryModelDepartures departure)
        {
            throw new NotImplementedException();
        }

        public List<RepositoryModelDepartures> GetAllDepartures()
        {
            var departureList = new List<RepositoryModelDepartures>();
            var repositoryModelDeparture = new RepositoryModelDepartures()
            {
                Id = 1,
                departureTime = "12:00"
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
                departureTime = "12:00"
            };
            departureList.Add(dbDepartures);
            departureList.Add(dbDepartures);
            departureList.Add(dbDepartures);
            return departureList;
        }

        public RepositoryModelDepartures GetDepartureByID(int id)
        {
            if (id == 0) return null;
            var repositoryModelDeparture = new RepositoryModelDepartures()
            {
                Id = id,
                departureTime = "12:00"
            };

            return repositoryModelDeparture;
        }

        public List<DbDepartures> GetDeparturesLater(string departureTime)
        {
            if (departureTime.Equals("")) return null;
            DateTime dateTime = DateTime.ParseExact(departureTime, "HH:mm", null);
            var departureList = new List<DbDepartures>();
            var dbDepartures = new DbDepartures()
            {
                Id = 1,
                departureTime = "16:00"
            };
            if (DateTime.ParseExact(dbDepartures.departureTime, "HH:mm", null) > dateTime)
            {
                departureList.Add(dbDepartures);
                departureList.Add(dbDepartures);
                departureList.Add(dbDepartures);
                return departureList;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateDeparture(int id, RepositoryModelDepartures departure)
        {
            if (id == 0) return false;
            else if (departure == null) return false;
            else return true;
        }
    }
}