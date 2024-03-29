﻿using System;
using System.Collections.Generic;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class StationRepositoryStub : IStationRepository
    {
        public StationRepositoryStub()
        {
        }

        public RepositoryModelStation DbToServiceStation(DbStation dbStation)
        {
            if (dbStation == null) return null;
            return new RepositoryModelStation
            {
                Id = dbStation.Id,
                NumberOnLine = dbStation.NumberOnLine,
                StationName = dbStation.StationName,
                TrainLine = dbStation.TrainLine
            };
        }

        public List<RepositoryModelStation> GetAllStations()
        {
            var list = new List<RepositoryModelStation>();
            var repositoryModelStation = new RepositoryModelStation()
            {
                Id = 1,
                NumberOnLine = 1,
                StationName = "Lillestrøm"
            };
            var repositoryModelStation2 = new RepositoryModelStation()
            {
                Id = 1,
                NumberOnLine = 1,
                StationName = "Oslo S"
            };

            list.Add(repositoryModelStation);
            list.Add(repositoryModelStation2);
            list.Add(repositoryModelStation);
            list.Add(repositoryModelStation2);

            return list;
        }

        public RepositoryModelStation GetStationById(int id)
        {
            if (id == 0) return null;
            var repositoryModelStation = new RepositoryModelStation()
            {
                Id = id,
                NumberOnLine = 1,
                StationName = "StasjonsNavn1"
            };
            return repositoryModelStation;
        }

        public List<DbStation> GetStationsFromNames(string fromStation, string toStation)
        {
            if (fromStation.Equals("")) return null;
            if (toStation.Equals("")) return null;
            var list = new List<DbStation>();
            var dbStation = new DbStation()
            {
                Id = 1,
                NumberOnLine = 1,
                StationName = toStation
            };
            var dbStation2 = new DbStation()
            {
                Id = 1,
                NumberOnLine = 1,
                StationName = fromStation
            };
            list.Add(dbStation2);
            list.Add(dbStation);

            return list;
        }

        public List<string> ServiceAutocomplete(string input)
        {
            if (input == "") return null;
            var liste = new List<string>();
            liste.Add(input);
            return liste;
        }

        public List<string> ServiceAutocompleteTo(string input, string fromStation)
        {
            if (input == "") return null;
            var liste = new List<string>();
            liste.Add(input);
            liste.Add(fromStation);
            liste.Add(fromStation);
            liste.Add(input);
            return liste;
        }

        public bool UpdateStation(int id, RepositoryModelStation stationIn)
        {
            if (id == 0) return false;
            return stationIn != null;
        }

        public bool AddStation(RepositoryModelStation station)
        {
            return true;
        }

        public bool DeleteStation(int id)
        {
            return true;
        }
    }
}