using Data.Access.Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace MVC.Controllers
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