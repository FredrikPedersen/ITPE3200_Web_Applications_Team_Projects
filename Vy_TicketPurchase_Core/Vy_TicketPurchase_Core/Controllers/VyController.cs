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
    }
}