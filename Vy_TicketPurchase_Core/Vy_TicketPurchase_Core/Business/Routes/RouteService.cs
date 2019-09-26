using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Business.Routes.Models;
using Vy_TicketPurchase_Core.Models.DBModels;

namespace Vy_TicketPurchase_Core.Business.Routes
{
    public class RouteService
    {
        private readonly DatabaseContext _databaseContext;

        public RouteService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public BusinessRoute GetRouteById(int id)
        {
            return DbToBusinessRoute(_databaseContext.Routes.FirstOrDefault(r => r.Id == id));
        }
        
        public List<BusinessRoute> GetAllRoutes()
        {
            return _databaseContext.Routes.Select(r => new BusinessRoute
            {
                Id = r.Id,
                StartLocation = r.StartLocation,
                StopLocation = r.StopLocation,
                Price = r.Price,
                TravelTimeMinutes = r.TravelTimeMinutes
            }).ToList();
        }

        private BusinessRoute DbToBusinessRoute(DbRoute dbRoute)
        {
            return new BusinessRoute
            {
                Id = dbRoute.Id,
                StartLocation = dbRoute.StartLocation,
                StopLocation = dbRoute.StopLocation,
                Price = dbRoute.Price,
                TravelTimeMinutes = dbRoute.TravelTimeMinutes
            };
        }
    }
}