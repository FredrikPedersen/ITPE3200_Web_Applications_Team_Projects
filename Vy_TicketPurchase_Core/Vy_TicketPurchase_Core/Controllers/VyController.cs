﻿using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business.Stations;
using Vy_TicketPurchase_Core.Business.Tickets;
using Vy_TicketPurchase_Core.Business.Tickets.Models;

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
            var isValidFromStation = false;
            var isValidToStation = false;
            
            if (ModelState.IsValid)
            {
                foreach (var station in _stationService.GetAllStations())
                {
                    if (ticket.FromStation == station.StationName)
                    {
                        isValidFromStation = true;
                    }
                    if (ticket.ToStation == station.StationName)
                    {
                        isValidToStation = true;
                    }
                }
                if (isValidToStation && isValidFromStation)
                {
                    _ticketService.SaveTicket(ticket);
                    return RedirectToAction("List", "List");
                }
            }
            
            //If the user inputs a station that does not exist, show an error message
            ModelState.AddModelError("Stations", "En av stasjonene du har skrevet inn finnes ikke"); //TODO This should be displayed in the same fashion as the error message for choosing the same to and from station!
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

        public JsonResult GetPassengerTypes()
        {
            return Json(_ticketService.GetAllPassengerTypes());
        }
    }
}