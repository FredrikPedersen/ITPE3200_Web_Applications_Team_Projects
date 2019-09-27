using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.ViewModels;
using Vy_TicketPurchase_Core.Services.Stations;

namespace Vy_TicketPurchase_Core.Controllers.Testing
{
    public class TestingController : Controller
    {

        private readonly StationService _stationService;

        public TestingController(StationService stationService)
        {
            _stationService = stationService;
        }
        
        public ActionResult Testing()
        {
            var model = new IndexModel {Stations = _stationService.GetAllStations()};

            return View(model);
        }
    }
}