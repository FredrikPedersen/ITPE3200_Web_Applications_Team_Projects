using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business.Tickets;
using Vy_TicketPurchase_Core.ViewModels;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class ListController : Controller
    {
        private readonly TicketService _ticketService;

        public ListController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }
        
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