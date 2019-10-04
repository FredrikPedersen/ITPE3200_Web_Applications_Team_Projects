using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Models.ViewModels;
using Vy_TicketPurchase_Core.Services.Stations;
using Vy_TicketPurchase_Core.Services.Tickets;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class VyController : Controller
    {
        private readonly StationService _stationService;
        private readonly TicketService _ticketService;
        private readonly LineService _lineService;

        public VyController(TicketService ticketService, StationService stationService, LineService lineService)
        {
            _ticketService = ticketService;
            _stationService = stationService;
            _lineService = lineService;
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

        public JsonResult Autocomplete(string input)
        {
            return Json(_stationService.ServiceAutocomplete(input));
        }

        public ActionResult LineMap()
        {
            var model = new ListLineModel
            {
                trainlines = _lineService.GetAllLines()
            };

            return View(model);
        }
    }
}