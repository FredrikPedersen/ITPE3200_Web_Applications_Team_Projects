using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Vy_TicketPurchase.Models.DBModels;
using Vy_TicketPurchase.Models.DomainModels;

namespace Vy_TicketPurchase.Controllers
{
    public class VyController : Controller
    {

        // GET: Vy
        public ActionResult Index()
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