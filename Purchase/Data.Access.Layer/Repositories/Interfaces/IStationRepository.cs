using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access.Layer.Repositories
{
    public interface IStationRepository
    {
        RepositoryModelStation GetStationById(int id);

        List<RepositoryModelStation> GetAllStations();

        RepositoryModelStation DbToServiceStation(DbStation dbStation);

        List<DbStation> GetStationsFromNames(string fromStation, string toStation);

        bool UpdateStation(int id, RepositoryModelStation stationIn);

        bool AddStation(RepositoryModelStation station);

        bool DeleteStation(int id);

        //TODO ActionResult?
    }
}