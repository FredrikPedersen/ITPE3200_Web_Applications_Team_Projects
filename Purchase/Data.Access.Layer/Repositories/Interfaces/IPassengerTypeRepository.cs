using System.Collections.Generic;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Interfaces
{
    public interface IPassengerTypeRepository
    {
        RepositoryModelPassengerType GetPassengerTypeTypeById(int id);

        RepositoryModelPassengerType DbToServicePT(DbPassengerType dbPassengerType);

        List<RepositoryModelPassengerType> GetAllPT();

        bool UpdatePT(int id, RepositoryModelPassengerType pt);
    }
}