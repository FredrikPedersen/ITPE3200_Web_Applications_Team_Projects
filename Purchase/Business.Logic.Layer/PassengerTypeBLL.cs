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
        private readonly IPassengerTypeRepository _passengerTypeRepositoryStub;
        private readonly PassengerTypeRepository _passengerTypeRepository;

        public PassengerTypeBLL(PassengerTypeRepository passengerTypeRepository)
        {
            _passengerTypeRepository = passengerTypeRepository;
        }

        public PassengerTypeBLL(IPassengerTypeRepository passengerTypeRepository)
        {
            _passengerTypeRepositoryStub = passengerTypeRepository;
        }

        public RepositoryModelPassengerType GetPassengerTypeTypeById(int id)
        {
            return _passengerTypeRepository.GetPassengerTypeTypeById(id);
        }

        public RepositoryModelPassengerType DbToServicePT(DbPassengerType dbPassengerType)
        {
            return _passengerTypeRepository.DbToServicePt(dbPassengerType);
        }

        public List<RepositoryModelPassengerType> GetAllPT()
        {
            return _passengerTypeRepository.GetAllPt();
        }

        public bool UpdatePT(int id, RepositoryModelPassengerType pt)
        {
            return _passengerTypeRepository.UpdatePt(id, pt);
        }
    }
}
