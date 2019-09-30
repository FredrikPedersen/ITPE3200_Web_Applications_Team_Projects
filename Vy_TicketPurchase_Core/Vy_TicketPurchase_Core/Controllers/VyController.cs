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
            DbCustomer customer = new DbCustomer {
                Name = ticket.CustomerName,
                Phonenumber = ticket.CustomerNumber
            };
            DbTicket newTicket = new DbTicket
            {
                //stasjon til og fra objekt
                ValidFrom = ticket.ValidFrom,
                DbCustomer = customer
            };
            //her kommer kode for å legge inn i databasen
            return RedirectToAction("ListView"); //må lage listeview
        }
    }
}