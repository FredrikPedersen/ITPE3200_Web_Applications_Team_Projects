using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access.Layer.Repositories
{
    public interface IPassengerTypeRepository
    {
        RepositoryModelPassengerType GetPassengerTypeTypeById(int id);

        RepositoryModelPassengerType DbToServicePT(DbPassengerType dbPassengerType);

        List<RepositoryModelPassengerType> GetAllPT();

        bool UpdatePT(int id, RepositoryModelPassengerType pt);

        bool AddPT(RepositoryModelPassengerType passengerType);

        bool DeletePT(int id);
    }
}