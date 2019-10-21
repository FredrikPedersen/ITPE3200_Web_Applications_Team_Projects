using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business;
using Vy_TicketPurchase_Core.Business.Stations;
using Vy_TicketPurchase_Core.Business.Tickets;
using Vy_TicketPurchase_Core.Business.Tickets.Models;
using Vy_TicketPurchase_Core.Repository.DBModels;
using Vy_TicketPurchase_Core.ViewModels;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class SelectTripController : Controller
    {

        private readonly TicketService _ticketService;
        private readonly DepartureService _departureService;
        private readonly StationService _stationService;
        
        public SelectTripController(DepartureService departureService, TicketService ticketService, StationService stationService)
        {
            _departureService = departureService;
            _ticketService = ticketService;
            _stationService = stationService;
        }
        
        [HttpPost]
        public ActionResult SelectTrip(SelectTripModel model)
        {
            
            //TODO Problemet ligger i å passere viewmodellen fra en controller til en annen. Forklarer tanken her når vi møtes - Fredrik
            SelectTripModel tempModel = (SelectTripModel) TempData["selecTrip"];
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAA");
            Console.WriteLine(tempModel.ticket.PasengerType);
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

            _ticketService.SaveTicket(model.ticket, GetStationsFromNames(model.ticket.FromStation, model.ticket.ToStation));
            return RedirectToAction("List", "List", model.ticket);
        }
        
        private List<DbStation> GetStationsFromNames(string toStation, string fromStation)
        {
            return _stationService.GetStationsFromNames(toStation, fromStation);
        }
        
    }
}