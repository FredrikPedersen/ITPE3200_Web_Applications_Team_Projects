using Microsoft.AspNetCore.Mvc;
using Purchase.Data.Access.Layer.Services;
using Purchase.Model.ViewModels;

namespace Purchase.MVC.Controllers
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