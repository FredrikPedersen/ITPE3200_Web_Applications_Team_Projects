using Model.DBModels;
using Model.RepositoryModels;
using System.Collections.Generic;

namespace Purchase.Data.Access.Layer.Repositories
{
    public interface IDepartureRepository
    {
        RepositoryModelDepartures GetDepartureByID(int id);
        List<RepositoryModelDepartures> GetAllDepartures();
        List<DbDepartures> GetAllDeparturesDB();
        List<DbDepartures> GetDeparturesLater(string departureTime);
        bool UpdateDeparture(int id, RepositoryModelDepartures departure);
        RepositoryModelDepartures DbtoServiceDeparture(DbDepartures departure);
    }
}