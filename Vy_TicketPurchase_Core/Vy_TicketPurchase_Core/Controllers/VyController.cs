using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vy_TicketPurchase_Core.Business;
using Vy_TicketPurchase_Core.Business.Stations;
using Vy_TicketPurchase_Core.Business.Tickets;
using Vy_TicketPurchase_Core.Repository.DBModels;
using Vy_TicketPurchase_Core.ViewModels;

namespace Vy_TicketPurchase_Core.Controllers
{
    public class VyController : Controller
    {
        private readonly StationService _stationService;
        private readonly TicketService _ticketService;
        private readonly DepartureService _departureService;

        public VyController(TicketService ticketService, StationService stationService, DepartureService departureService)
        {
            _ticketService = ticketService;
            _stationService = stationService;
            _departureService = departureService;
        }

        public ActionResult Index()
        {
            ViewBag.PassengerTypes = PassengerTypesForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            var isValidFromStation = false;
            var isValidToStation = false;

            if (ModelState.IsValid)
            {
                foreach (var station in _stationService.GetAllStations())
                {
                    if (model.Ticket.FromStation == station.StationName)
                    {
                        isValidFromStation = true;
                    }
                    if (model.Ticket.ToStation == station.StationName)
                    {
                        isValidToStation = true;
                    }
                }
                
                if (isValidToStation && isValidFromStation)
                {

                    SelectTripModel selectTripModel = new SelectTripModel
                    {
                        departures = _departureService.GetAllDepartures(),
                        ticket = model.Ticket
                    };
                    
                    return View("SelectTrip", selectTripModel);
                }
            }

            //If the user inputs a station that does not exist, show an error message
            ModelState.AddModelError("Stations", "En av stasjonene du har skrevet inn finnes ikke"); //TODO This should be displayed in the same fashion as the error message for choosing the same to and from station!
            return View();
        }

        //Calls autocomplete method for "From" text box in Index View
        public JsonResult Autocomplete(string input)
        {
            return Json(_stationService.ServiceAutocomplete(input));
        }

        //Calls autocomplete method for "To" text box in Index View
        public JsonResult AutocompleteTo(string input, string fromStation)
        {
            return Json(_stationService.ServiceAutocompleteTo(input, fromStation));
        }

        public JsonResult GetPassengerTypes()
        {
            return Json(_ticketService.GetAllPassengerTypes());
        }

        private SelectList PassengerTypesForDropdown()
        {
            List <DbPassengerType> types = _ticketService.GetAllPassengerTypes();
            string[] typeNames = new string[types.Capacity-1];
            
            for (var i = 0; i < types.Capacity-1; i++)
            {
                typeNames[i] = types[i].Type;
            }
            
            return new SelectList(typeNames);
        }
    }
}