﻿using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business.Stations
{
    public class LineService
    {
        private readonly DatabaseContext _databaseContext;

        public LineService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public List<DbTrainLine> GetAllLines()
        {
            return _databaseContext.TrainLines.Select(s => new DbTrainLine
            {
                Stations = s.Stations
            }).ToList();
        }

        public bool SaveLine(DbTrainLine newLine)
        {
            try
            {
                _databaseContext.TrainLines.Add(newLine);
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}