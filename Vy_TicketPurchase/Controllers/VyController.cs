using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Vy_TicketPurchase.Models;
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

        public string GetAllRoutes()
        {
            var db = new RouteDB();
            List<DomainRoute> allRoutes = db.GetAllRoutes();
            
            var dropdownDisplayRoute = new List<JsRoute>();
            foreach (DomainRoute dr in allRoutes)
            {
                var oneRoute = new JsRoute();
                oneRoute.Id = dr.Id;
                oneRoute.RouteName = dr.Startlocation + " - " + dr.Stoplocation;
                dropdownDisplayRoute.Add(oneRoute);
            }

            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(dropdownDisplayRoute);
            return json;
        }
    }
}