using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.ViewModels;
using Vy_TicketPurchase_Core.Services.Routes;
using Vy_TicketPurchase_Core.Services.Routes.Models;

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
            var model = new IndexModel {Routes = _routeService.GetAllRoutes()};

            return View(model);
        }
    }
}