using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class VyController : Controller
    {
        private readonly Services.Stations.StationService stationService;
        private readonly Services.Tickets.TicketService ticketService;
        // GET: Vy
        public ActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ServiceModelTicket ticket) 
        {
            ticketService.saveTicket(ticket);
            return RedirectToAction("List", "List");
        }

      
        public JsonResult Autocomplete(string input)
       {
            return Json(stationService.ServiceAutocomplete(input));
        }

    }
}