using Purchase.Data.Access.Layer.Repositories;
using Purchase.Model.DBModels;
using Purchase.Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic.Layer
{
    class DepartureBLL
    {
        private readonly IDepartureRepository _departureRepository;

        public DepartureBLL(IDepartureRepository departureRepo)
        {
            _departureRepository = departureRepo;
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
    }
}
