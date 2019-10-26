using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
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
            var list = new List<DbStation>();
            var dbStation = new DbStation()
            {
                Id = 1,
                NumberOnLine = 1,
                StationName = "StasjonsNavn1"
            };
            list.Add(dbStation);
            list.Add(dbStation);
            list.Add(dbStation);
            
            var line = new DbTrainLine()
            {
                Id = 123,
                Name = "test",
                Stations = list
            };

            return line;
        }

        public RepositoryModelTrainLine DbLineToRepository(DbTrainLine dbTrainLine)
        {
            return null;
        }

        public List<DbTrainLine> GetAllLines()
        {
            List<DbTrainLine> lines = new List<DbTrainLine>();
            var list = new List<DbStation>();
            var dbStation = new DbStation()
            {
                Id = 1,
                NumberOnLine = 1,
                StationName = "StasjonsNavn1"
            };
            list.Add(dbStation);
            list.Add(dbStation);
            list.Add(dbStation);
            
            var line = new DbTrainLine()
            {
                Id = 123,
                Name = "test",
                Stations = list
            };
            
            lines.Add(line);
            lines.Add(line);
            lines.Add(line);

            return lines;
        }

        public bool UpdateLine(DbTrainLine trainLineIn)
        {
            return true;
        }
    }
}