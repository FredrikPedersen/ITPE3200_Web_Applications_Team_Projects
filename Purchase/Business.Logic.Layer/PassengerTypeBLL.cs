using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories.Interfaces;
using Data.Access.Layer.Repositories.Repository;

namespace Business.Logic.Layer
{
    public class PassengerTypeBLL
    {
        private readonly IPassengerTypeRepository _passengerTypeRepository;

        public PassengerTypeBLL(IPassengerTypeRepository passengerTypeRepository)
        {
            _passengerTypeRepository = passengerTypeRepository;
        }

        public RepositoryModelPassengerType GetPassengerTypeTypeById(int id)
        {
            return _passengerTypeRepository.GetPassengerTypeTypeById(id);
        }

        public RepositoryModelPassengerType DbToServicePt(DbPassengerType dbPassengerType)
        {
            return _passengerTypeRepository.DbToServicePt(dbPassengerType);
        }

        public List<RepositoryModelPassengerType> GetAllPt()
        {
            return _passengerTypeRepository.GetAllPt();
        }

        public bool UpdatePt(int id, RepositoryModelPassengerType pt)
        {
            return _passengerTypeRepository.UpdatePt(id, pt);
        }
    }
}