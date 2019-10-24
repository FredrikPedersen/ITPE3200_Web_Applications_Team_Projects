﻿using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Business.PassengerType.Models;
using Vy_TicketPurchase_Core.Business.Stations.Models;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business.PassengerType
{
    public class PassengerTypeService
    {
        private readonly DatabaseContext _databaseContext;

        public PassengerTypeService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ServiceModelPassengerType GetPassengerTypeTypeById(int id)
        {
            return DbToServicePT(_databaseContext.PassengerTypes.FirstOrDefault(r => r.Id == id));
        }

        public ServiceModelPassengerType DbToServicePT(DbPassengerType dbPassengerType)
        {
            return new ServiceModelPassengerType()
            {
                Id = dbPassengerType.Id,
                Type = dbPassengerType.Type,
                PriceMultiplier = dbPassengerType.PriceMultiplier
            };

        }

        public List<ServiceModelPassengerType> GetAllPT()
        {
            return _databaseContext.PassengerTypes.Select(t => new ServiceModelPassengerType()
            {
                Id = t.Id,
                Type = t.Type,
                PriceMultiplier = t.PriceMultiplier
            }).ToList();
        }

        public bool UpdatePT(int id, ServiceModelPassengerType pt)
        {
            DbPassengerType passengerType = _databaseContext.PassengerTypes.Find(id);
            passengerType.PriceMultiplier = pt.PriceMultiplier;
            _databaseContext.PassengerTypes.Update(passengerType);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}