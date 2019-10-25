using Business.Logic.Layer;
using Data.Access.Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.RepositoryModels;
using Model.ViewModels;
using Unit.Testing;

namespace MVC.Controllers

{
    public class AdminController : Controller
    {
        private Class1 _class1; //DO NOT REMOVE THIS BEFORE WE MAKE ACTUAL USE OF THE BLL!!! NBNB!NB!NB!!!!!
        private Class2 _class2; //DO NOT REMOVE THIS BEFORE WE MAKE ACTUAL USE OF THE Unit.Testing!!! NBNB!NB!NB!!!!!
        private readonly StationRepository _stationService;
        private readonly TicketRepository _tickedService;
        private readonly DepartureRepository _departureService;
        private readonly PassengerTypeRepository _passengerTypeService;


        public AdminController(StationRepository stationService, TicketRepository tickedService,
            DepartureRepository departureService, PassengerTypeRepository passengerTypeService
        )
        {
            _stationService = stationService;
            _tickedService = tickedService;
            _departureService = departureService;
            _passengerTypeService = passengerTypeService;
        }

        public ActionResult Admin()
        {
            var model = new AdminModel()
            {
                Stations = _stationService.GetAllStations(),
                //Tickets = _tickedService.GetAllTickets(),
                Departures = _departureService.GetAllDepartures(),
                Types = _passengerTypeService.GetAllPT()
            };

            return View(model);
        }

        public ActionResult EditStation(int id)
        {
            var Station = _stationService.GetStationById(id);

            //ViewBag.station = _stationService.GetStationById(id);
            return View(Station);
        }

        [HttpPost]
        public ActionResult EditStation(RepositoryModelStation stationIn)
        {
            if (ModelState.IsValid)
            {
                _stationService.UpdateStation(stationIn.Id, stationIn);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }

        public ActionResult EditPassengerType(int id)
        {
            var Type = _passengerTypeService.GetPassengerTypeTypeById(id);
            return View(Type);
        }

        [HttpPost]
        public ActionResult EditPassengerType(RepositoryModelPassengerType type)
        {
            if (ModelState.IsValid)
            {
                _passengerTypeService.UpdatePT(type.Id, type);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }

        public ActionResult EditDeparture(int id)
        {
            var departure = _departureService.GetDepartureByID(id);
            return View(departure);
        }

        [HttpPost]
        public ActionResult EditDeparture(RepositoryModelDepartures departure)
        {
            if (ModelState.IsValid)
            {
                _departureService.UpdateDeparture(departure.Id, departure);
                return RedirectToAction("Admin", "Admin");
            }

            return View();
        }
    }
}