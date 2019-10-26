using System;
using System.Collections.Generic;
using System.Linq;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Interfaces
{
    public interface ILineRepository
    {


         DbTrainLine GetLineById(int id);


         RepositoryModelTrainLine DbLineToRepository(DbTrainLine dbTrainLine);


         List<DbTrainLine> GetAllLines();


         bool UpdateLine(DbTrainLine trainLineIn);

    }
}