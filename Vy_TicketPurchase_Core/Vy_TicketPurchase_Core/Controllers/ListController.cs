using Microsoft.AspNetCore.Mvc;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class ListController : Controller
    {
        // GET
        public IActionResult List()
        {
            return View();
        }
    }
}