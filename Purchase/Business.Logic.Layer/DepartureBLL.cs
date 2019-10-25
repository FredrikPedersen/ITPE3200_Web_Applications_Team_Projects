﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories;
using Data.Access.Layer.Repositories.Interfaces;
using Data.Access.Layer.Repositories.Repository;
using Model.DBModels;
using Model.RepositoryModels;

namespace Business.Logic.Layer
{
    public class DepartureBLL
    {
        private readonly IDepartureRepository _departureRepositoryStub;
        private readonly DepartureRepository _departureRepository;

        public DepartureBLL(IDepartureRepository departureRepositoryStub)
        {
            //_departureRepositoryStub = departureStub;
        }
        
        public DepartureBLL(DepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public RepositoryModelDepartures GetDepartureByID(int id)
        {
            return _departureRepository.GetDepartureByID(id);
        }

        public RepositoryModelDepartures DbtoServiceDeparture(DbDepartures departure)
        {
            return _departureRepository.DbtoServiceDeparture(departure);
        }

        public List<RepositoryModelDepartures> GetAllDepartures()
        {
            return _departureRepository.GetAllDepartures();
        }

        public List<DbDepartures> GetAllDeparturesDB()
        {
            return _departureRepository.GetAllDeparturesDB();
        }

        public List<DbDepartures> GetDeparturesLater(string departureTime)
        {
            return _departureRepository.GetDeparturesLater(departureTime);
        }

        public bool UpdateDeparture(int id, RepositoryModelDepartures departure)
        {
            return _departureRepository.UpdateDeparture(id, departure);
        }

        public bool AddDeparture(RepositoryModelDepartures departure)
        {
            return _departureRepository.AddDeparture(departure);
        }

    }
}