using System;
using System.Collections.Generic;
using System.Linq;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories
{
    public class LineRepository
    {
        private readonly DatabaseContext _databaseContext;

        public LineRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public DbTrainLine GetLineById(int id)
        {
            return _databaseContext.TrainLines.FirstOrDefault(r => r.Id == id);
        }

        private RepositoryModelTrainLine DbLineToRepository(DbTrainLine dbTrainLine)
        {
            return new RepositoryModelTrainLine()
            {
                Id = dbTrainLine.Id,
                Name = dbTrainLine.Name,
                Stations = dbTrainLine.Stations
            };
        }

        public List<DbTrainLine> GetAllLines()
        {
            return _databaseContext.TrainLines.Select(l => new DbTrainLine()
            {
                Id = l.Id,
                Name = l.Name,
                Stations = l.Stations
            }).ToList();
        }
    }
}