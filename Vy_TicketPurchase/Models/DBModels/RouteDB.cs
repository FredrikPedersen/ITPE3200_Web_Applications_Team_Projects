using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase.Models.DomainModels;

namespace Vy_TicketPurchase.Models
{
    public class RouteDB
    {
        
        DB db = new DB();

        public List<DomainRoute> GetAllRoutes()
        {
            List<DomainRoute> allRoutes = db.Routes.Select(r => new DomainRoute()
            {
                id = r.id,
                startlocation = r.startlocation,
                stoplocation = r.stoplocation,
                price = r.price,
                travelTimeMinutes = r.travelTimeMinutes
            }).ToList();
            return allRoutes;
        }
    }
}