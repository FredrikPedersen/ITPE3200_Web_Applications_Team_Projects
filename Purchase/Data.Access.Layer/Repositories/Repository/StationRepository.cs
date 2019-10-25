using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Repository
{
    public class StationRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StationRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public RepositoryModelStation GetStationById(int id)
        {
            return DbToServiceStation(_databaseContext.Stations.FirstOrDefault(r => r.Id == id));
        }

        public List<RepositoryModelStation> GetAllStations()
        {
            return _databaseContext.Stations.Select(s => new RepositoryModelStation
            {
                Id = s.Id,
                NumberOnLine = s.NumberOnLine,
                StationName = s.StationName,
                TrainLine = s.TrainLine
            }).ToList();
        }

        private RepositoryModelStation DbToServiceStation(DbStation dbStation)
        {
            return new RepositoryModelStation
            {
                Id = dbStation.Id,
                NumberOnLine = dbStation.NumberOnLine,
                StationName = dbStation.StationName,
                TrainLine = dbStation.TrainLine
            };
        }

        public List<DbStation> GetStationsFromNames(string fromStation, string toStation)
        {
            var stations = new List<DbStation>();
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
        //TODO MOVE THIS TO BLL
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
        //TODO MOVE THIS TO BLL
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

        public bool UpdateStation(int id, RepositoryModelStation stationIn)
        {
            var station = _databaseContext.Stations.Find(id);

            station.StationName = stationIn.StationName;
            _databaseContext.Stations.Update(station);
            _databaseContext.SaveChanges();
            return true;
        }
    }
}