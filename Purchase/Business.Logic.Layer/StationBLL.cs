using Data.Access.Layer.Repositories;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories.Interfaces;
using Data.Access.Layer.Repositories.Repository;

namespace Business.Logic.Layer
{
    public class StationBLL
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

        public List<DbStation> GetStationsFromNames(string fromStation, string toStation)
        {
            return _stationRepository.GetStationsFromNames(fromStation, toStation);
        }

        public int UpdateStation(int id, RepositoryModelStation stationIn)
        {
            return _stationRepository.UpdateStation(id, stationIn);
        }

        public List<string> ServiceAutocomplete(string input)
        {
            return _stationRepository.ServiceAutocomplete(input);
        }

        public List<string> ServiceAutocompleteTo(string input, string fromStation)
        {
            return _stationRepository.ServiceAutocompleteTo(input, fromStation);
        }

        public bool AddStation(RepositoryModelStation station)
        {
            return _stationRepository.AddStation(station);
        }

        public bool DeleteStation(int id)
        {
            return _stationRepository.DeleteStation(id);
        }
    }
}