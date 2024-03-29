﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data.Access.Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.DBModels;
using Model.RepositoryModels;
using Utilities.Logging;

namespace Data.Access.Layer.Repositories.Repository
{
    public class LineRepository : ILineRepository
    {
        private readonly DatabaseContext _databaseContext;

        public LineRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public DbTrainLine GetLineById(int id)
        {
            var trainLines = GetAllLines();//_databaseContext.TrainLines.FirstOrDefault(r => r.Id == id);
            var wantedTrainline = new DbTrainLine();
            foreach (var trainline in trainLines)
            {
                if (trainline.Id == id)
                {
                    wantedTrainline = trainline;
                }
            }
            return wantedTrainline;
        }

        public RepositoryModelTrainLine DbLineToRepository(DbTrainLine dbTrainLine)
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

        public bool UpdateLine(DbTrainLine trainLineIn)
        {
            var line = GetLineById(trainLineIn.Id);
            line.Stations = trainLineIn.Stations;

            try
            {
                _databaseContext.TrainLines.Update(line);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                ErrorLogger.LogError(ex);
                return false;
            }
        }
    }
}