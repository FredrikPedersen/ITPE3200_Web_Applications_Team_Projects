using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.ViewModels;
using Vy_TicketPurchase_Core.Services.Stations;
using Vy_TicketPurchase_Core.Services.Tickets;

namespace Vy_TicketPurchase_Core.Controllers.Testing
{
    public class ListModelTestingController : Controller
    {
        private readonly TicketService _ticketService;

        public ListModelTestingController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }
        // GET
        public IActionResult ListTesting()
        {
            var model = new ListModel
            {
                Tickets = _ticketService.GetAllTickets()
            };
            
            return View(model);
        }
    }
}