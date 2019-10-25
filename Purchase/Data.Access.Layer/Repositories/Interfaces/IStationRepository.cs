using System.Collections.Generic;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Interfaces
{
    public interface IStationRepository
    {
        RepositoryModelStation GetStationById(int id);

        List<RepositoryModelStation> GetAllStations();

        RepositoryModelStation DbToServiceStation(DbStation dbStation);

        List<DbStation> GetStationsFromNames(string fromStation, string toStation);

        bool UpdateStation(int id, RepositoryModelStation stationIn);

        List<string> ServiceAutocomplete(string input);

        List<string> ServiceAutocompleteTo(string input, string fromStation);
    }
}