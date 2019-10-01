using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.DBModels;
using Vy_TicketPurchase_Core.Services.Tickets.Models;

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
        public ActionResult Index(ServiceModelTicket ticket) 
        {
            //if (TicketService.saveTicket(ticket)){success} else{failed};
            return RedirectToAction("List","List"); //må lage listeview
        }
    }
}