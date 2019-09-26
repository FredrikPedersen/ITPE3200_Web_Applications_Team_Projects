using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business.Routes;
using Vy_TicketPurchase_Core.Business.Routes.Models;

namespace Vy_TicketPurchase_Core.Controllers.Testing
{
    public class TestingController : Controller
    {

        private readonly RouteService _routeService;

        public TestingController(RouteService routeService)
        {
            _routeService = routeService;
        }
        
        public ActionResult Testing()
        {
            var routes = _routeService.GetAllRoutes();
            return View(routes);
        }

        private List<BusinessRoute> GetRouteFromId(List<Int32> routeIds)
        {
            List<BusinessRoute> routes = new List<BusinessRoute>();
            foreach (var routeId in routeIds)
            {
                var route = _routeService.GetRouteById(routeId);
                if (route != null)
                    routes.Add(route);
            }

            return routes;
        }

        
        
    }
}