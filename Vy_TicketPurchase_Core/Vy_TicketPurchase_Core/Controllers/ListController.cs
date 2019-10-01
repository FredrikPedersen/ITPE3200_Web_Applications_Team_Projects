using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.ViewModels;
using Vy_TicketPurchase_Core.Services.Stations;
using Vy_TicketPurchase_Core.Services.Tickets;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class ListController : Controller
    {
        private readonly TicketService _ticketService;

        public ListController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET
        public IActionResult List()
        {
            var model = new ListModel
            {
                Tickets = _ticketService.GetAllTickets()
            };

            return View(model);
        }
    }

}