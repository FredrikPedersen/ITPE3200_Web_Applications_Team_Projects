﻿using System;
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
        private readonly StationService _stationService; //TODO Instantiate these

        private readonly TicketService _ticketService;

        public VyController(TicketService ticketService, StationService stationService)
        {
            _ticketService = ticketService;
            _stationService = stationService;
        }
        // GET: Vy
        public ActionResult Index() 
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(ServiceModelTicket ticket) 
        {
            _ticketService.SaveTicket(ticket);
            return RedirectToAction("List","List"); //må lage listeview
        }

      
        public JsonResult Autocomplete(string input)
       {
            return Json(_stationService.ServiceAutocomplete(input));
        }

    }
}