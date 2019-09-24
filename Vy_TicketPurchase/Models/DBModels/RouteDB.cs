using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase.Models.DomainModels;

namespace Vy_TicketPurchase.Models.DBModels
{
    public class RouteDB
    {
        
        private DatabaseContext databaseContext = new DatabaseContext();

        public List<DomainRoute> GetAllRoutes()
        {
            List<DomainRoute> allRoutes = databaseContext.Routes.Select(r => new DomainRoute()
            {
                Id = r.Id,
                StartLocation = r.Startlocation,
                StopLocation = r.Stoplocation,
                Price = r.Price,
                TravelTimeMinutes = r.TravelTimeMinutes
            }).ToList();
            return allRoutes;
        }
        
        public DomainRoute GetOneRoute(int id)
        {
            Route routeFromDb = databaseContext.Routes.Find(id);

            var aRoute = new DomainRoute()
            {
                Id = routeFromDb.Id,
                StartLocation = routeFromDb.Startlocation,
                StopLocation = routeFromDb.Stoplocation,
                Price = routeFromDb.Price,
                TravelTimeMinutes = routeFromDb.TravelTimeMinutes,
            };
            return aRoute;
        }
    }
}