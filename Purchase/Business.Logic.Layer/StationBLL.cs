using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic.Layer
{
    internal class StationBLL
    {
        private readonly IStationRepository _stationRepository;

        public StationBLL(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public RepositoryModelStation GetStationById(int id)
        {
            return _stationRepository.GetStationById(id);
        }

        public List<RepositoryModelStation> GetAllStations()
        {
            return _stationRepository.GetAllStations();
        }

        public RepositoryModelStation DbToServiceStation(DbStation dbStation)
        {
            return _stationRepository.DbToServiceStation(dbStation);
        }

        public List<DbStation> GetStationsFromNames(string fromStation, string toStation)
        {
            return _stationRepository.GetStationsFromNames(fromStation, toStation);
        }

        public bool UpdateStation(int id, RepositoryModelStation stationIn)
        {
            return _stationRepository.UpdateStation(id, stationIn);
        }
    }
}