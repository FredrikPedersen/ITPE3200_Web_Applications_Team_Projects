﻿using System;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business;
using Vy_TicketPurchase_Core.Business.Departures;
using Vy_TicketPurchase_Core.Business.PassengerType;
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
            DepartureService departureService,PassengerTypeService passengerTypeService
            )
        {
            _stationService = stationService;
            _tickedService = tickedService;
            _departureService = departureService;
            _passengerTypeService = passengerTypeService;
        }

        public ActionResult Admin()
        {
            var model = new AdminModel
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
            
            ViewBag.station = _stationService.GetStationById(id);
            return View(Station);
        }
        [HttpPost]
        public ActionResult EditStation(ServiceModelStation stationIn)
        {
            
            if (ModelState.IsValid)
            {
                Console.WriteLine(stationIn.StationName + "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Console.WriteLine(stationIn.NumberOnLine + "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                Console.WriteLine(stationIn.Id + "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                _stationService.UpdateStation(stationIn.Id, stationIn);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }

    }
}