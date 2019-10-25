using System.Collections.Generic;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Interfaces
{
    public interface IDepartureRepository
    {
        RepositoryModelDepartures GetDepartureByID(int id);

        List<RepositoryModelDepartures> GetAllDepartures();

        List<DbDepartures> GetAllDeparturesDB();

        List<DbDepartures> GetDeparturesLater(string departureTime);

        bool UpdateDeparture(int id, RepositoryModelDepartures departure);

        RepositoryModelDepartures DbToServiceDeparture(DbDepartures departure);

        bool AddDeparture(RepositoryModelDepartures departure);

        bool DeleteDeparture(int id);
    }
}