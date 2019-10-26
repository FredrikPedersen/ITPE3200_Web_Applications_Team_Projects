using System.Collections.Generic;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Interfaces
{
    public interface IPassengerTypeRepository
    {
        RepositoryModelPassengerType GetPassengerTypeTypeById(int id);

        RepositoryModelPassengerType DbToServicePt(DbPassengerType dbPassengerType);

        List<RepositoryModelPassengerType> GetAllPt();

        bool AddPT(RepositoryModelPassengerType passengerType);

        bool DeletePT(int id);
        bool UpdatePt(int id, RepositoryModelPassengerType pt);
    }
}