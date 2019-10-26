using System.Collections.Generic;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Interfaces
{
    public interface IPassengerTypeRepository
    {
        List<RepositoryModelPassengerType> GetAllPt();
        
    }
}