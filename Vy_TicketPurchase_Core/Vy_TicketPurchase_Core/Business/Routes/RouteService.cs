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
            this._databaseContext = dbContext;
        }

        public Route GetRouteById(int id)
        {
            return DbToBusinessRoute(_databaseContext.Routes.FirstOrDefault(r => r.Id == id));
        }

        private Route DbToBusinessRoute(DbRoute dbRoute)
        {
            return new Route
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