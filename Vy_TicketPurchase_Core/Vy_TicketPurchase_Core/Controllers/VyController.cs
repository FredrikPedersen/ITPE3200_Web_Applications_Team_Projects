using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.DBModels;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class VyController : Controller
    {

        // GET: Vy
        public ActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Services.Tickets.Models.ServiceModelTicket ticket) //kommer inn i metoden, men vet ikke hva slags objekt som må være her, kanskje lage et nytt med alle attributtene?
        {
            Console.WriteLine("linje før");
            Console.WriteLine(ticket);
            Console.WriteLine("linje etter");
            return View();
            //return RedirectToAction();
        }
    }
}