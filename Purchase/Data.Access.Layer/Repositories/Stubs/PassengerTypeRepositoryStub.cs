using System;
using System.Collections.Generic;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class PassengerTypeRepositoryStub : IPassengerTypeRepository
    {
        public PassengerTypeRepositoryStub()
        {
        }

        public RepositoryModelPassengerType DbToServicePt(DbPassengerType dbPassengerType)
        {
            if (dbPassengerType == null) return null;
            return new RepositoryModelPassengerType()
            {
                Id = dbPassengerType.Id,
                Type = dbPassengerType.Type,
                PriceMultiplier = dbPassengerType.PriceMultiplier
            };
        }

        public List<RepositoryModelPassengerType> GetAllPt()
        {
            var list = new List<RepositoryModelPassengerType>();
            var repo = new RepositoryModelPassengerType
            {
                Id = 1,
                Type = "Adult",
                PriceMultiplier = 3.0
            };
            list.Add(repo);
            list.Add(repo);
            list.Add(repo);
            return list;
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

        public bool UpdatePt(int id, RepositoryModelPassengerType pt)
        {
            if (id == 0) return false;
            return pt != null;
        }

        public bool AddPT(RepositoryModelPassengerType passengerType)
        {
            throw new NotImplementedException();
        }

        public bool DeletePT(int id)
        {
            throw new NotImplementedException();
        }
    }
}