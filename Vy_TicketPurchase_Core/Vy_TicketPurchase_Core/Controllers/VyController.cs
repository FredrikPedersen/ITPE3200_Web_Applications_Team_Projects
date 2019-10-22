using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business;
using Vy_TicketPurchase_Core.Business.Stations;
using Vy_TicketPurchase_Core.Business.Tickets;
using Vy_TicketPurchase_Core.Business.Tickets.Models;
using Vy_TicketPurchase_Core.Repository.DBModels;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class VyController : Controller
    {
        private readonly StationService _stationService;
        private readonly TicketService _ticketService;
        private readonly DepartureService _departureService;

        public VyController(TicketService ticketService, StationService stationService, DepartureService departureService)
        {
            _ticketService = ticketService;
            _stationService = stationService;
            _departureService = departureService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestSelectTrip()
        {
            List<DbDepartures> departures = _departureService.GetAllDepartures();
            return View(departures);
        }

        [HttpPost]
        public ActionResult TestSelectTrip(ServiceModelTicket ticket)
        {
            _ticketService.SaveTicket(ticket, GetStationsFromNames(ticket.FromStation, ticket.ToStation));
            return RedirectToAction("List", "List", ticket);
        }

        public ActionResult ToAdmin()
        {
            return RedirectToAction("Admin", "Admin");
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
                    List<DbDepartures> departures = _departureService.GetAllDepartures();
                    //   _ticketService.SaveTicket(ticket, GetStationsFromNames(ticket.FromStation, ticket.ToStation));
                    ViewBag.ticket = ticket;
                    return View("testSelectTrip", departures);
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

        private List<DbStation> GetStationsFromNames(string toStation, string fromStation)
        {
            return _stationService.GetStationsFromNames(toStation, fromStation);
        }

        public JsonResult GetPassengerTypes()
        {
            return Json(_ticketService.GetAllPassengerTypes());
        }
    }
}