using Purchase.Model.DBModels;
using Purchase.Model.RepositoryModels;
using System.Collections.Generic;

namespace Purchase.Data.Access.Layer.Repositories
{
    public interface IDepartureRepository
    {
       RepositoryModelDepartures GetDepartureByID(int id);
        RepositoryModelDepartures DbtoServiceDeparture(DbDepartures departure);
        List<RepositoryModelDepartures> GetAllDepartures();
        List<DbDepartures> GetAllDeparturesDB();
        List<DbDepartures> GetDeparturesLater(string departureTime);
        bool UpdateDeparture(int id, RepositoryModelDepartures departure);
    }
}