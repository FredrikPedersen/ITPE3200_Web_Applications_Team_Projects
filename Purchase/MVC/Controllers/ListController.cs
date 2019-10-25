using Business.Logic.Layer;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace MVC.Controllers
{
    public class ListController : Controller
    {
        private readonly TicketBLL _ticketBll;

        public ListController(TicketBLL ticketBll)
        {
            _ticketBll = ticketBll;
        }
        
        public IActionResult List()
        {
            var model = new ListModel
            {
                Tickets = _ticketBll.GetAllTickets()
            };

            return View(model);
        }
    }

}