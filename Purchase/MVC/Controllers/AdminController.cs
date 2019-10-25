using System;
using Business.Logic.Layer;
using Data.Access.Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.RepositoryModels;
using Model.ViewModels;

namespace MVC.Controllers

{
    public class AdminController : Controller
    {
        private Class1 _class1; //DO NOT REMOVE THIS BEFORE WE MAKE ACTUAL USE OF THE BLL!!! NBNB!NB!NB!!!!!
        private readonly StationRepository _stationService;
        private readonly TicketRepository _tickedService;
        private readonly DepartureRepository _departureService;
        private readonly PassengerTypeRepository _passengerTypeService;
        private readonly DepartureBLL _departureBll;
        private readonly StationBLL _stationBll;
        private readonly TicketBLL _ticketBll;
        private readonly UserBLL _userBll;
        private readonly PassengerTypeBLL _passengerTypeBll;

        public AdminController(DepartureBLL departureBll, StationBLL stationBll, TicketBLL ticketBll, UserBLL userBll,
            PassengerTypeBLL passengerTypeBll
        )
        {
            _departureBll = departureBll;
            _stationBll = stationBll;
            _ticketBll = ticketBll;
            _userBll = userBll;
            _passengerTypeBll = passengerTypeBll;
        }

        public ActionResult Admin()
        {
            var model = new AdminModel()
            {
                Stations = _stationBll.GetAllStations(),
                //Tickets = _tickedService.GetAllTickets(),
                Departures = _departureBll.GetAllDepartures(),
                Types = _passengerTypeBll.GetAllPT()
            };

            return View(model);
        }

        public ActionResult AddStation()
        {
            var station = new RepositoryModelStation();
            return View("EditStation");
        }

        public ActionResult EditStation(int id)
        {
            var Station = _stationBll.GetStationById(id);

            //ViewBag.station = _stationService.GetStationById(id);
            return View(Station);
        }

        [HttpPost]
        public ActionResult EditStation(RepositoryModelStation stationIn)
        {
            if (ModelState.IsValid)
            {
                _stationBll.UpdateStation(stationIn.Id, stationIn);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }

        public ActionResult EditPassengerType(int id)
        {
            var Type = _passengerTypeBll.GetPassengerTypeTypeById(id);
            return View(Type);
        }

        [HttpPost]
        public ActionResult EditPassengerType(RepositoryModelPassengerType type)
        {
            if (ModelState.IsValid)
            {
                _passengerTypeBll.UpdatePT(type.Id, type);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }

        //ADD
        public ActionResult AddDeparture()
        {
            var departure = new RepositoryModelDepartures();
            return View("EditDeparture");
        }

        //EDIT
        public ActionResult EditDeparture(int id)
        {
            var departure = _departureBll.GetDepartureByID(id);
            return View(departure);
        }

        //ADD+EDIT POST
        [HttpPost]
        public ActionResult EditDeparture(RepositoryModelDepartures departure)
        {
            if (ModelState.IsValid)
            {
                if (departure.Id != 0)
                {
                    _departureBll.UpdateDeparture(departure.Id, departure);
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    _departureBll.AddDeparture(departure);
                    return RedirectToAction("Admin", "Admin");
                }
            }

            return View();
        }
    }
}