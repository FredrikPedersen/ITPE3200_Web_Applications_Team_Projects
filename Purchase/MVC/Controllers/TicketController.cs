using Business.Logic.Layer;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels;

namespace MVC.Controllers
{
    public class TicketController : Controller
    {
        public readonly TicketBLL TicketBll;

        public TicketController(TicketBLL ticketBll)
        {
            TicketBll = ticketBll;
        }
        
        public IActionResult Ticket()
        {

            var ticketList = TicketBll.GetAllTickets();
            var model = ticketList[ticketList.Count - 1];

            return View(model);
        }
    }

}