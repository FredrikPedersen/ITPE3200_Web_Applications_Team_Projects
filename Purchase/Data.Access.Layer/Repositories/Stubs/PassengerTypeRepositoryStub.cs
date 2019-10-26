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
    }
}