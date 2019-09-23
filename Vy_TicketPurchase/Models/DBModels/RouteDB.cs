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
                Startlocation = r.Startlocation,
                Stoplocation = r.Stoplocation,
                Price = r.Price,
                TravelTimeMinutes = r.TravelTimeMinutes
            }).ToList();
            return allRoutes;
        }
    }
}