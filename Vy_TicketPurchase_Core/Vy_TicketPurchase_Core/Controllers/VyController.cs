using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Stations;
using Vy_TicketPurchase_Core.Services.Tickets;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class VyController : Controller
    {
        private readonly StationService _stationService;

        private readonly TicketService _ticketService;

        public VyController(TicketService ticketService, StationService stationService)
        {
            _ticketService = ticketService;
            _stationService = stationService;
        }
        
        public ActionResult Index() 
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(ServiceModelTicket ticket) 
        { 
            if (ModelState.IsValid)
            {
                _ticketService.SaveTicket(ticket);
                return RedirectToAction("List", "List");
            }
            return View();
        }
        
        //Calls autocomplete method for "From" text box in Index View
        public JsonResult Autocomplete(string input)
        {
            return Json(_stationService.ServiceAutocomplete(input));
        }
        
        //Calls autocomplete method for "To" text box in Index View
        public JsonResult AutocompleteTo(string input, string fromStation)
        {
            return Json(_stationService.ServiceAutocompleteTo(input, fromStation));
        }
    }
}