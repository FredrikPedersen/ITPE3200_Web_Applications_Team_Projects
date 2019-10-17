using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business.Stations.Models;
using Vy_TicketPurchase_Core.Repository;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Business.Stations
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

        public List<DbStation> GetStationsFromNames(string fromStation, string toStation)
        {
            List<DbStation> stations = new List<DbStation>();
            DbStation fromStationObject = null;
            DbStation toStationObject = null;
            
            foreach (var station in _databaseContext.Stations)
            {
                if (fromStation.Equals(station.StationName))
                    fromStationObject = station;

                if (toStation.Equals(station.StationName))
                    toStationObject = station;
            }

            stations.Add(fromStationObject);
            stations.Add(toStationObject);
            return stations;
        }
        
        //Method that gets information for the "From" autocomplete in the Index View
        [HttpPost]
        public List<string> ServiceAutocomplete(string input)
        {
            using (_databaseContext)
            {
                var result = (from station in _databaseContext.Stations where station.StationName.Contains(input) select station.StationName).Distinct().ToList();
                return result;
            }
        }
        
        //Method that gets information for the "To" autocomplete in the Index View depending on content of the "From" text box
        [HttpPost]
        public List<string> ServiceAutocompleteTo(string input, string fromStation)
        {
            var lineList = (from station in _databaseContext.Stations
                where station.StationName == fromStation
                select station.TrainLine.Id).ToList();

            var result = new List<string>();
            
            foreach (var line in lineList)
            {
                var tempList = new List<string>(from station in _databaseContext.Stations where station.StationName.Contains(input) && station.TrainLine.Id == line select station.StationName).Distinct().ToList();
                foreach (var value in tempList)
                {
                    if (!(result.Contains(value)))
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }
    }
}