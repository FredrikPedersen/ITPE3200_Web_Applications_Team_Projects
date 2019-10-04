using Microsoft.AspNetCore.Mvc;
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
                StationName = s.StationName,
            }).ToList();
        }

        private ServiceModelStation DbToServiceStation(DbStation dbStation)
        {
            return new ServiceModelStation
            {
                Id = dbStation.Id,
                StationName = dbStation.StationName,
            };
        }
        [HttpPost]
        public List<string> ServiceAutocomplete(string input)
        {
            using (_databaseContext)
            {
                var result = (from station in _databaseContext.Stations where station.StationName.Contains(input) select station.StationName).ToList();
                return result;
            }
        }
        
        [HttpPost]
        public List<string> ServiceAutocompleteTo(string input, string from)
        {
            var result = new List<string>();
            var fromStation = from
                var fromStationId =


            using (_databaseContext)
            {
                var stationList = (from trainline in _databaseContext.TrainLines where trainline.Id == idT select trainline.stations);
                foreach (var VARIABLE in stationList)
                {
                    foreach (var stasjon in VARIABLE)
                    {
                        result.Add(stasjon.StationName);
                    }
                }
            }
            return result;
        }


    }
}