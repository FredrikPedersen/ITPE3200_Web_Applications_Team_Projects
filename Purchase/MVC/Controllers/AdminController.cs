using System;
using Business.Logic.Layer;
using Data.Access.Layer.Repositories;
using Data.Access.Layer.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using Model.DBModels;
using Model.RepositoryModels;
using Model.ViewModels;

namespace MVC.Controllers

{
    public class AdminController : Controller
    {
        private readonly StationRepository _stationService;
        private readonly TicketRepository _tickedService;
        private readonly DepartureRepository _departureService;
        private readonly PassengerTypeRepository _passengerTypeService;
        private readonly DepartureBLL _departureBll;
        private readonly StationBLL _stationBll;
        private readonly TicketBLL _ticketBll;
        private readonly UserBLL _userBll;
        private readonly PassengerTypeBLL _passengerTypeBll;
        private readonly LineBLL _lineBll;


        public AdminController(DepartureBLL departureBll, StationBLL stationBll, TicketBLL ticketBll, UserBLL userBll,
            PassengerTypeBLL passengerTypeBll, LineBLL lineBll
        )
        {
            _departureBll = departureBll;
            _stationBll = stationBll;
            _ticketBll = ticketBll;
            _userBll = userBll;
            _passengerTypeBll = passengerTypeBll;
            _lineBll = lineBll;
        }

        public ActionResult Admin()
        {
            
            var model = new AdminModel()
            {
                Stations = _stationBll.GetAllStations(),
                //Tickets = _tickedService.GetAllTickets(),
                Departures = _departureBll.GetAllDepartures(),
                Types = _passengerTypeBll.GetAllPT(),
                Lines = _lineBll.GetAllLines()
            };

            return View(model);
        }

        public ActionResult EditLine(int id)
        {
            var line = _lineBll.GetLineById(id);
            Console.WriteLine(line.Name);
            return View(line);
        }

        public ActionResult AddStation(int line)
        {
            var tempLine = _lineBll.GetLineById(line);
            return View("EditStation");
        }

        public ActionResult EditStation(int id)
        {
            var Station = _stationBll.GetStationById(id);
            return View(Station);
        }

        [HttpPost]
        public ActionResult EditStation(RepositoryModelStation stationIn)
        {
            var dbLine = new DbTrainLine()
            {
                Id = ViewBag.Trainline.Id,
                Name = ViewBag.Trainline.Name,
                Stations = ViewBag.Trainline.Stations
            };

            stationIn.TrainLine = dbLine;

            if (ModelState.IsValid)
            {
                if (stationIn.Id != 0)
                {
                    _stationBll.UpdateStation(stationIn.Id, stationIn);
                    return RedirectToAction("EditLine", "Admin");
                }
                else
                {
                    _stationBll.AddStation(stationIn);
                    return RedirectToAction("EditLine", "Admin");
                }
            }

            return View();
        }

        public ActionResult DeleteStation(int id)
        {
            Console.WriteLine(id + "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            _stationBll.DeleteStation(id);
            return RedirectToAction("Admin", "Admin");
        }

        public ActionResult AddPT()
        {
            var pt = new RepositoryModelPassengerType();
            return View("EditPassengerType", pt);
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
                if (type.Id != 0)
                {
                    _passengerTypeBll.UpdatePT(type.Id, type);
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    _passengerTypeBll.AddPT(type);
                    return RedirectToAction("Admin", "Admin");
                }
            }

            return View();
        }

        public ActionResult DeletePT(int id)
        {
            _passengerTypeBll.DeletePT(id);
            return RedirectToAction("Admin", "Admin");
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

        public ActionResult DeleteDeparture(int id)
        {
            _departureBll.DeleteDeparture(id);
            return RedirectToAction("Admin", "Admin");
        }
    }
}