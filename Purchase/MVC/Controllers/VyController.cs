using System;
using System.Collections.Generic;
using Business.Logic.Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.DBModels;
using Model.RepositoryModels;
using Utilities.Passwords;

namespace MVC.Controllers
{
    public class VyController : Controller
    {
        private const string SessionKey = "_Key";
        private const string Logged = "Logged";
        private const string NotLogged = "notLogged";
        private readonly TicketBLL _ticketBll;
        private readonly DepartureBLL _departureBll;
        private readonly StationBLL _stationBll;
        private readonly UserBLL _userBll;

        public VyController(TicketBLL ticketBll, DepartureBLL departureBll, StationBLL stationBll, UserBLL userBll)
        {
            _ticketBll = ticketBll;
            _departureBll = departureBll;
            _stationBll = stationBll;
            _userBll = userBll;
        }

        public ActionResult Index()
        {
            ViewBag.PassengerTypes = PassengerTypesForDropdown();
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKey))) {
                HttpContext.Session.SetString("_Key", NotLogged);
            }
            
            return View();
        }

        public ActionResult ToAdmin()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKey)))
            {
                Console.WriteLine(HttpContext.Session.GetString(SessionKey));
                var logged = HttpContext.Session.GetString(SessionKey);
                if (logged.Equals(Logged))
                {
                    return RedirectToAction("Admin", "Admin");
                }
            }
            ViewBag.PassengerTypes = PassengerTypesForDropdown();
            return View("Index");
        }

        [HttpPost]
        public ActionResult LogIn(RepositoryModelUser user)
        {
            if (_userBll.CheckUser(user))
            {
                HttpContext.Session.SetString(SessionKey, Logged);
                ViewBag.Logged = false;
                return RedirectToAction("ToAdmin", "Vy");
            }

            HttpContext.Session.SetString(SessionKey, NotLogged);
            ViewBag.Logged = true;
            ViewBag.PassengerTypes = PassengerTypesForDropdown();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(RepositoryModelTicket ticket)
        {
            var isValidFromStation = false;
            var isValidToStation = false;
            if (ModelState.IsValid)
            {
                foreach (var station in _stationBll.GetAllStations())
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
                    var departures = _departureBll.GetDeparturesLater(ticket.ValidFromTime);
                    ViewBag.ticket = ticket;

                    return View("SelectTrip", departures);
                }
            }

            //TODO This should be displayed in the same fashion as the error message for choosing the same to and from station!
            //If the user inputs a station that does not exist, show an error message
            ModelState.AddModelError("Stations", "En av stasjonene du har skrevet inn finnes ikke");
            return View();
        }

        [HttpPost]
        public ActionResult SelectTrip(RepositoryModelTicket ticket)
        {
            _ticketBll.SaveTicket(ticket, GetStationsFromNames(ticket.FromStation, ticket.ToStation));
            return RedirectToAction("Ticket", "Ticket", ticket);
        }

        //Calls autocomplete method for "From" text box in Index View
        public JsonResult Autocomplete(string input)
        {
            return Json(_stationBll.ServiceAutocomplete(input));
        }

        //Calls autocomplete method for "To" text box in Index View
        public JsonResult AutocompleteTo(string input, string fromStation)
        {
            return Json(_stationBll.ServiceAutocompleteTo(input, fromStation));
        }

        public JsonResult GetPassengerTypes()
        {
            return Json(_ticketBll.GetAllPassengerTypes());
        }

        private SelectList PassengerTypesForDropdown()
        {
            //TODO Vi får dobbeltlagring av passasjertyper. UNDERSØK SENERE!
            var types = _ticketBll.GetAllPassengerTypes();
            var typeNames = new string[4];

            for (var i = 0; i < 4; i++)
            {
                typeNames[i] = types[i].Type;
            }

            return new SelectList(typeNames);
        }

        private List<DbStation> GetStationsFromNames(string toStation, string fromStation)
        {
            return _stationBll.GetStationsFromNames(toStation, fromStation);
        }
    }
}