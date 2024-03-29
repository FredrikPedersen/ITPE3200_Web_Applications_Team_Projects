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
        private readonly IDepartureRepository _departureRepository;

        public DepartureBLL(IDepartureRepository departureRepository)
        {
            _departureRepository = departureRepository;
        }

        public RepositoryModelDepartures GetDepartureById(int id)
        {
            return _departureRepository.GetDepartureById(id);
        }

        public List<RepositoryModelDepartures> GetAllDepartures()
        {
            return _departureRepository.GetAllDepartures();
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

        public bool DeleteDeparture(int id)
        {
            return _departureRepository.DeleteDeparture(id);
        }

    }
}