using Microsoft.AspNetCore.Mvc;
using Vy_TicketPurchase_Core.Business.Stations;
using Vy_TicketPurchase_Core.Business.Stations.Models;
using Vy_TicketPurchase_Core.ViewModels;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class AdminController : Controller
    {
        private readonly StationService _stationService;

        public AdminController(StationService stationService)
        {
            _stationService = stationService;
        }

        public ActionResult Admin()
        {
            var model = new AdminModel
            {
                Stations = _stationService.GetAllStations()
            };
            
            return View(model);
        }

        public ActionResult EditStation(int id)
        {
            var model = new AdminModel
            {
                Station = _stationService.GetStationById(id)
            };
            
            return View(model);
        }

    }
}