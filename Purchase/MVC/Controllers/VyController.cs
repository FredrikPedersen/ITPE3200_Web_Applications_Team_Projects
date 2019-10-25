using System;
using System.Collections.Generic;
using Data.Access.Layer.Repositories;
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
        private readonly StationRepository _stationService;
        private readonly TicketRepository _ticketService;
        private readonly DepartureRepository _departureService;
        private readonly UserRepository _userService;

        private const string SessionKey = "_Key";

        public VyController(TicketRepository ticketService, StationRepository stationService,
            DepartureRepository departureService, UserRepository userService)
        {
            _ticketService = ticketService;
            _stationService = stationService;
            _departureService = departureService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            ViewBag.PassengerTypes = PassengerTypesForDropdown();
            return View();
        }

        public ActionResult ToAdmin()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKey)))
            {
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAa");
                Console.WriteLine(HttpContext.Session.GetString(SessionKey));
                string logged = HttpContext.Session.GetString(SessionKey);
                if (logged.Equals("Logged"))
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
            Console.WriteLine(user.UserName + "LOGGGGGGGGGGGGGGGGGGGGGGGGG");
            if (_userService.CheckUser(user))
            {
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAYEYEYEYYEYEYEYEEYEYAa");
                HttpContext.Session.SetString(SessionKey, "Logged");
                ViewBag.Logged = false;
            }
            else
            {
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAANONONONONOONONONa");
                HttpContext.Session.SetString(SessionKey, "NotLogged");
                
                ViewBag.Logged = true;
            }
            
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
                    List<DbDepartures> departures = _departureService.GetDeparturesLater(ticket.ValidFromTime);
                    ViewBag.ticket = ticket;

                    return View("SelectTrip", departures);
                }
            }

            //If the user inputs a station that does not exist, show an error message
            ModelState.AddModelError("Stations",
                "En av stasjonene du har skrevet inn finnes ikke"); //TODO This should be displayed in the same fashion as the error message for choosing the same to and from station!
            return View();
        }

        [HttpPost]
        public ActionResult SelectTrip(RepositoryModelTicket ticket)
        {
            _ticketService.SaveTicket(ticket, GetStationsFromNames(ticket.FromStation, ticket.ToStation));
            return RedirectToAction("List", "List", ticket);
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

        private SelectList PassengerTypesForDropdown()
        {
            //TODO Vi får dobbeltlagring av passasjertyper. UNDERSØK SENERE!
            List <DbPassengerType> types = _ticketService.GetAllPassengerTypes();
            string[] typeNames = new string[4];

            for (var i = 0; i < 4; i++)
            {
                typeNames[i] = types[i].Type;
            }

            return new SelectList(typeNames);
        }
        
        

        private List<DbStation> GetStationsFromNames(string toStation, string fromStation)
        {
            return _stationService.GetStationsFromNames(toStation, fromStation);
        }

        //________________________________________________________________________________________

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RepositoryModelUser user)
        {
            try
            {
                var newUser = new DbUser();
                byte[] salt = Hasher.CreateSalt();
                byte[] hash = Hasher.CreateHash(user.Password, salt);
                newUser.UserName = user.UserName;
                newUser.Password = hash;
                newUser.Salt = salt;
                _userService.AddUser(newUser);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }
    }
}