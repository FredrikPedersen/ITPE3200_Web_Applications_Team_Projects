﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Stations.Models;

namespace Vy_TicketPurchase_Core.Services.Stations
{
    public class StationService
    {
        private readonly DatabaseContext _databaseContext;

        public StationService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public ServiceModelStation GetStationById(int id)
        {
            return DbToServiceStation(_databaseContext.Stations.FirstOrDefault(r => r.Id == id));
        }
        
        public List<ServiceModelStation> GetAllStations()
        {
            return _databaseContext.Stations.Select(s => new ServiceModelStation
            {
                Id = s.Id,
                NumberOnLine = s.NumberOnLine,
                StationName = s.StationName,
                TrainLine = s.TrainLine
            }).ToList();
        }

        private ServiceModelStation DbToServiceStation(DbStation dbStation)
        {
            return new ServiceModelStation
            {
                Id = dbStation.Id,
                NumberOnLine = dbStation.NumberOnLine,
                StationName = dbStation.StationName,
                TrainLine = dbStation.TrainLine
            };
        }
        [HttpPost]
        public List<string> ServiceAutocomplete(string input)
        {
            using (_databaseContext)
            {
                var result = (from station in _databaseContext.Stations where station.StationName.Contains(input) && station.TrainLine.Id == 1 select station.StationName).Distinct().ToList();
                return result;
            }
        }


    }
}