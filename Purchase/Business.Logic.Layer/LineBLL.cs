using System.Collections.Generic;
using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using Data.Access.Layer.Repositories.Interfaces;


namespace Business.Logic.Layer
{
    public class LineBLL
    {
        private readonly ILineRepository _lineRepository;

        public LineBLL(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;
        }

        public DbTrainLine GetLineById(int id)
        {
            return _lineRepository.GetLineById(id);
        }

        public List<DbTrainLine> GetAllLines()
        {
            return _lineRepository.GetAllLines();
        }

        public bool UpdateLine(DbTrainLine trainLineIn)
        {
            return _lineRepository.UpdateLine(trainLineIn);
        }
    }
}