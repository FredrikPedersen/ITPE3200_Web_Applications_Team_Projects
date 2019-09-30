using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Models.ViewModels;
using Vy_TicketPurchase_Core.Services.Stations;

namespace Vy_TicketPurchase_Core.Controllers.Testing
{
    public class IndexModelTestingController : Controller
    {

        private readonly StationService _stationService;

        public IndexModelTestingController(StationService stationService)
        {
            _stationService = stationService;
        }
        
        public ActionResult IndexTesting()
        {
            var model = new IndexModel {Stations = _stationService.GetAllStations()};

            return View(model);
        }
    }
}