using System.Collections.Generic;
using System.Linq;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Repository
{
    public class PassengerTypeRepository : IPassengerTypeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PassengerTypeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        

        public List<RepositoryModelPassengerType> GetAllPt()
        {
            return _databaseContext.PassengerTypes.Select(t => new RepositoryModelPassengerType()
            {
                Id = t.Id,
                Type = t.Type,
                PriceMultiplier = t.PriceMultiplier
            }).ToList();
        }
    }
}