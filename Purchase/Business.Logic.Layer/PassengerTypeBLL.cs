using Model.DBModels;
using Model.RepositoryModels;
using System.Collections.Generic;
using Data.Access.Layer.Repositories.Interfaces;

namespace Business.Logic.Layer
{
    public class PassengerTypeBLL
    {
        private readonly IPassengerTypeRepository _passengerTypeRepository;

        public PassengerTypeBLL(IPassengerTypeRepository passengerTypeRepository)
        {
            _passengerTypeRepository = passengerTypeRepository;
        }

        public List<RepositoryModelPassengerType> GetAllPt()
        {
            return _passengerTypeRepository.GetAllPt();
        }
    }
}