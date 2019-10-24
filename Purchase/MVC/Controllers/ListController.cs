using Microsoft.AspNetCore.Mvc;
using Purchase.Data.Access.Layer.Repositories;
using Purchase.Model.ViewModels;

namespace Purchase.MVC.Controllers
{
    public class ListController : Controller
    {
        private readonly TicketRepository _ticketService;

        public ListController(TicketRepository ticketService)
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