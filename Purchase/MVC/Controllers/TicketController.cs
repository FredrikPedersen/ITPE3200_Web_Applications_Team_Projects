using Business.Logic.Layer;
using Microsoft.AspNetCore.Mvc;
using Model.RepositoryModels;
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
            RepositoryModelTicket model;

            if (ticketList.Count == 0)
                model = new RepositoryModelTicket
                {
                    ValidFromDate = "01.01.1970",
                    ValidFromTime = "12:00",
                    FromStation = "Oslo S",
                    ToStation = "Trondheim",
                    Price = 100,
                    CustomerGivenName = "Ola",
                    CustomerLastName = "Nordmann",
                    CustomerNumber = "12345678"
                };
            else
                model = ticketList[ticketList.Count - 1];

            return View(model);
        }
    }

}