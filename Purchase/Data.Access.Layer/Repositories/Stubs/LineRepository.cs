using System;
using System.Collections.Generic;
using System.Linq;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class LineRepositoryStub : ILineRepository
    {
        private readonly DatabaseContext _databaseContext;

        public LineRepositoryStub()
        {
            
        }

        public DbTrainLine GetLineById(int id)
        {
           
            return null;
        }

        public RepositoryModelTrainLine DbLineToRepository(DbTrainLine dbTrainLine)
        {
            return null;
        }

        public List<DbTrainLine> GetAllLines()
        {
            return null;
        }

        public bool UpdateLine(DbTrainLine trainLineIn)
        {
            return true;
        }
    }
}