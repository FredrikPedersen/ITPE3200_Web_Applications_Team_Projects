using System;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business;
using Vy_TicketPurchase_Core.Business.Departures;
using Vy_TicketPurchase_Core.Business.Departures.Models;
using Vy_TicketPurchase_Core.Business.PassengerType;
using Vy_TicketPurchase_Core.Business.PassengerType.Models;
using Vy_TicketPurchase_Core.Business.Stations;
using Vy_TicketPurchase_Core.Business.Stations.Models;
using Vy_TicketPurchase_Core.Business.Tickets;
using Vy_TicketPurchase_Core.ViewModels;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class AdminController : Controller
    {
        private readonly StationService _stationService;
        private readonly TicketService _tickedService;
        private readonly DepartureService _departureService;
        private readonly PassengerTypeService _passengerTypeService;


        public AdminController(StationService stationService, TicketService tickedService,
            DepartureService departureService, PassengerTypeService passengerTypeService
        )
        {
            _stationService = stationService;
            _tickedService = tickedService;
            _departureService = departureService;
            _passengerTypeService = passengerTypeService;
        }

        public ActionResult Admin()
        {
            var model = new AdminModel()
            {
                Stations = _stationService.GetAllStations(),
                //Tickets = _tickedService.GetAllTickets(),
                Departures = _departureService.GetAllDepartures(),
                Types = _passengerTypeService.GetAllPT()
            };

            return View(model);
        }

        public ActionResult EditStation(int id)
        {
            var Station = _stationService.GetStationById(id);

            //ViewBag.station = _stationService.GetStationById(id);
            return View(Station);
        }

        [HttpPost]
        public ActionResult EditStation(ServiceModelStation stationIn)
        {
            if (ModelState.IsValid)
            {
                _stationService.UpdateStation(stationIn.Id, stationIn);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }

        public ActionResult EditPassengerType(int id)
        {
            var Type = _passengerTypeService.GetPassengerTypeTypeById(id);
            return View(Type);
        }

        [HttpPost]
        public ActionResult EditPassengerType(ServiceModelPassengerType type)
        {
            if (ModelState.IsValid)
            {
                _passengerTypeService.UpdatePT(type.Id, type);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }

        public ActionResult EditDeparture(int id)
        {
            var departure = _departureService.GetDepartureByID(id);
            return View(departure);
        }

        [HttpPost]
        public ActionResult EditDeparture(ServiceModelDepartures departure)
        {
            if (ModelState.IsValid)
            {
                _departureService.UpdateDeparture(departure.Id, departure);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }
    }
}