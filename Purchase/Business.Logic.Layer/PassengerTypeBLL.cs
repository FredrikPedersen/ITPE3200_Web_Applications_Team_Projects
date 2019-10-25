using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic.Layer
{
    public class PassengerTypeBLL
    {
        private readonly IPassengerTypeRepository _passangerTypeRepository;

        public PassengerTypeBLL(IPassengerTypeRepository passengerTypeRepository)
        {
            _passangerTypeRepository = passengerTypeRepository;
        }

        public RepositoryModelPassengerType GetPassengerTypeTypeById(int id)
        {
            return _passangerTypeRepository.GetPassengerTypeTypeById(id);
        }

        public RepositoryModelPassengerType DbToServicePT(DbPassengerType dbPassengerType)
        {
            return _passangerTypeRepository.DbToServicePT(dbPassengerType);
        }

        public List<RepositoryModelPassengerType> GetAllPT()
        {
            return _passangerTypeRepository.GetAllPT();
        }

        public bool UpdatePT(int id, RepositoryModelPassengerType pt)
        {
            return _passangerTypeRepository.UpdatePT(id, pt);
        }
    }
}
