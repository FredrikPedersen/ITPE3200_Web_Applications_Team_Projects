using System.Collections.Generic;
using System.Linq;
using Data.Access.Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.RepositoryModels;
using Utilities.Logging;

namespace Data.Access.Layer.Repositories.Repository
{
    public class PassengerTypeRepository : IPassengerTypeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PassengerTypeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public RepositoryModelPassengerType GetPassengerTypeTypeById(int id)
        {
            return DbToServicePt(_databaseContext.PassengerTypes.FirstOrDefault(r => r.Id == id));
        }

        public RepositoryModelPassengerType DbToServicePt(DbPassengerType dbPassengerType)
        {
            return new RepositoryModelPassengerType()
            {
                Id = dbPassengerType.Id,
                Type = dbPassengerType.Type,
                PriceMultiplier = dbPassengerType.PriceMultiplier
            };
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

        public bool UpdatePt(int id, RepositoryModelPassengerType pt)
        {
            var passengerType = _databaseContext.PassengerTypes.Find(id);
            passengerType.PriceMultiplier = pt.PriceMultiplier;

            try
            {
                _databaseContext.PassengerTypes.Update(passengerType);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                ErrorLogger.LogError(ex);
                return false;
            }
        }
    }
}