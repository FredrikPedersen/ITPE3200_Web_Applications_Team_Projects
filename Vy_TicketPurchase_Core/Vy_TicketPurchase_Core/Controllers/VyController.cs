﻿using System;
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
        public ActionResult Index(ServiceModelTicket ticket) //kommer inn i metoden, men vet ikke hva slags objekt som må være her, kanskje lage et nytt med alle attributtene?
        {
           
            //her kommer kode for å legge inn i databasen
            return RedirectToAction("List","List"); //må lage listeview
        }
    }
}