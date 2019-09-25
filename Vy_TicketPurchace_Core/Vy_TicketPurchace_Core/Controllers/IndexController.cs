using System;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase.Models.DBModels;

namespace Vy_TicketPurchace_Core.Controllers
{
    public class IndexController : Controller
    {
        private readonly DatabaseContext _context;

        public IndexController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
		
		public string GetAllRoutes() //Method called by JQuery script
        {
            var db = new RouteDB();
            List<DomainRoute> allRoutes = db.GetAllRoutes();
            
            var dropdownDisplayRoute = new List<JsRoute>();
            foreach (DomainRoute dr in allRoutes)
            {
                var oneRoute = new JsRoute();
                oneRoute.Id = dr.Id;
                oneRoute.RouteName = dr.StartLocation + " - " + dr.StopLocation;
                dropdownDisplayRoute.Add(oneRoute);
            }

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(dropdownDisplayRoute);
            return json;
        }
        
        public string GetRouteInfo(int id)
        {
            var db = new RouteDB();
            DomainRoute domainRoute = db.GetOneRoute(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(domainRoute);
            return json;
        }
    }
}