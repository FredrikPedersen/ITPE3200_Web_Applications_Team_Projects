using System.Collections.Generic;
using System.Linq;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Routes.Models;

namespace Vy_TicketPurchase_Core.Services.Routes
{
    public class RouteService
    {
        private readonly DatabaseContext _databaseContext;

        public RouteService(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public ServiceModelRoute GetRouteById(int id)
        {
            return DbToServiceRoute(_databaseContext.Routes.FirstOrDefault(r => r.Id == id));
        }
        
        public List<ServiceModelRoute> GetAllRoutes()
        {
            return _databaseContext.Routes.Select(r => new ServiceModelRoute
            {
                Id = r.Id,
                StartLocation = r.StartLocation,
                StopLocation = r.StopLocation,
                Price = r.Price,
                TravelTimeMinutes = r.TravelTimeMinutes
            }).ToList();
        }

        private ServiceModelRoute DbToServiceRoute(DbRoute dbRoute)
        {
            return new ServiceModelRoute
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