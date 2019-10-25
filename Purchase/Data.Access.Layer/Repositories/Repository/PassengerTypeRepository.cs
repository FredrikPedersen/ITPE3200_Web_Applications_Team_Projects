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

        public RepositoryModelPassengerType GetPassengerTypeTypeById(int id)
        {
            return DbToServicePT(_databaseContext.PassengerTypes.FirstOrDefault(r => r.Id == id));
        }

        public RepositoryModelPassengerType DbToServicePT(DbPassengerType dbPassengerType)
        {
            return new RepositoryModelPassengerType()
            {
                Id = dbPassengerType.Id,
                Type = dbPassengerType.Type,
                PriceMultiplier = dbPassengerType.PriceMultiplier
            };

        }

        public List<RepositoryModelPassengerType> GetAllPT()
        {
            return _databaseContext.PassengerTypes.Select(t => new RepositoryModelPassengerType()
            {
                Id = t.Id,
                Type = t.Type,
                PriceMultiplier = t.PriceMultiplier
            }).ToList();
        }

        public bool UpdatePT(int id, RepositoryModelPassengerType pt)
        {
            DbPassengerType passengerType = _databaseContext.PassengerTypes.Find(id);
            passengerType.PriceMultiplier = pt.PriceMultiplier;
            _databaseContext.PassengerTypes.Update(passengerType);
            _databaseContext.SaveChanges();
            return true;
        }

        public bool AddPT(RepositoryModelPassengerType passengerType)
        {
            var dbPt = new DbPassengerType()
            {
                Type = "Test",//passengerType.Type,
                PriceMultiplier = passengerType.PriceMultiplier
            };

            _databaseContext.PassengerTypes.Add(dbPt);
            _databaseContext.SaveChanges();
            return true;
        }

        public bool DeletePT(int id)
        {
            DbPassengerType dbPt = _databaseContext.PassengerTypes.FirstOrDefault(r => r.Id == id);
            _databaseContext.PassengerTypes.Remove(dbPt);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}