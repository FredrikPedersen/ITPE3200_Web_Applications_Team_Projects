using System;
using System.Collections.Generic;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class PassengerTypeRepositoryStub : IPassengerTypeRepository
    {
        public PassengerTypeRepositoryStub()
        {
        }

        public RepositoryModelPassengerType DbToServicePT(DbPassengerType dbPassengerType)
        {
            if (dbPassengerType == null) return null;
            return new RepositoryModelPassengerType()
            {
                Id = dbPassengerType.Id,
                Type = dbPassengerType.Type,
                PriceMultiplier = dbPassengerType.PriceMultiplier
            };
        }

        public List<RepositoryModelPassengerType> GetAllPT()
        {
            var liste = new List<RepositoryModelPassengerType>();
            var repo = new RepositoryModelPassengerType
            {
                Id = 1,
                Type = "Adult",
                PriceMultiplier = 3.0
            };
            liste.Add(repo);
            liste.Add(repo);
            liste.Add(repo);
            return liste;
        }

        public RepositoryModelPassengerType GetPassengerTypeTypeById(int id)
        {
            if (id == 0) return null;
            var repositoryModelPassengerType = new RepositoryModelPassengerType()
            {
                Id = id,
                Type = "Adult",
                PriceMultiplier = 3.0
            };
            return repositoryModelPassengerType;
        }

        public bool UpdatePT(int id, RepositoryModelPassengerType pt)
        {
            if (id == 0) return false;
            else if (pt == null) return false;
            else return true;
        }
    }
}