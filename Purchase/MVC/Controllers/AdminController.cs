using System;
using System.Threading.Tasks;
using Business.Logic.Layer;
using Data.Access.Layer.Repositories;
using Data.Access.Layer.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using Model.DBModels;
using Model.RepositoryModels;
using Model.ViewModels;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace MVC.Controllers

{
    public class AdminController : Controller
    {
        private readonly StationRepository _stationService;
        private readonly TicketRepository _tickedService;
        private readonly DepartureRepository _departureService;
        private readonly PassengerTypeRepository _passengerTypeService;
        public readonly DepartureBLL _departureBll;
        public readonly StationBLL _stationBll;
        public readonly TicketBLL _ticketBll;
        public readonly UserBLL _userBll;
        public readonly PassengerTypeBLL _passengerTypeBll;
        public readonly LineBLL _lineBll;


        public AdminController(DepartureBLL departureBll, StationBLL stationBll, TicketBLL ticketBll, UserBLL userBll,
            PassengerTypeBLL passengerTypeBll, LineBLL lineBll
        )
        {
            _departureBll = departureBll;
            _stationBll = stationBll;
            _ticketBll = ticketBll;
            _userBll = userBll;
            _passengerTypeBll = passengerTypeBll;
            _lineBll = lineBll;
        }

        public ActionResult Admin()
        {
            
            var model = new AdminModel()
            {
                Stations = _stationBll.GetAllStations(),
                //Tickets = _tickedService.GetAllTickets(),
                Departures = _departureBll.GetAllDepartures(),
                Types = _passengerTypeBll.GetAllPt(),
                Lines = _lineBll.GetAllLines()
            };
    
            return View(model);
        }

        public ActionResult EditLine(int id)
        {
            var model = new AdminModel()
            {
                Line = _lineBll.GetLineById(id)
            };
            ViewBag.line = _lineBll.GetLineById(id);
            return View(model);
        }

        
        public ActionResult AddStation(int id)
        {
            var line = id;
            var model = new AdminModel()
            {
                Line = _lineBll.GetLineById(id)
            };
            
            ViewBag.line = _lineBll.GetLineById(line);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult AddStation(AdminModel modelIn)
        {
            var lineIn = _lineBll.GetLineById(modelIn.Line.Id);

            var stationInDb = new DbStation()
            {
                StationName = modelIn.Station.StationName,
                NumberOnLine = modelIn.Station.NumberOnLine,
                TrainLine = lineIn
            };
            
            var stationIn = new RepositoryModelStation()
            {
                StationName = modelIn.Station.StationName,
                NumberOnLine = modelIn.Station.NumberOnLine,
                TrainLine = lineIn
            };
            
            _stationBll.AddStation(stationIn);

            lineIn.Stations.Add(stationInDb);
            _lineBll.UpdateLine(lineIn);

            ViewBag.line = lineIn;
            return View();
        }
        

        public ActionResult EditStation(int id, int line)
        {
            var model = new AdminModel()
            {
                Station = _stationBll.GetStationById(id),
                Line = _lineBll.GetLineById(line)
            };
            ViewBag.line = _lineBll.GetLineById(line);
            return View(model);
        }
        
        [HttpPost]
        public ActionResult EditStation(AdminModel modelIn)
        {
            var lineIn = _lineBll.GetLineById(modelIn.Line.Id);

                var stationInDb = new DbStation()
                {
                    Id = modelIn.Station.Id,
                    StationName = modelIn.Station.StationName,
                    NumberOnLine = modelIn.Station.NumberOnLine,
                    TrainLine = lineIn
                };
            
                var stationIn = new RepositoryModelStation()
                {
                    Id = modelIn.Station.Id,
                    StationName = modelIn.Station.StationName,
                    NumberOnLine = modelIn.Station.NumberOnLine,
                    TrainLine = lineIn
                };
            
                var result = _stationBll.UpdateStation(stationIn.Id, stationIn);
                
                
                for (int i = 0; i < lineIn.Stations.Count; i++)
                {
                    if (lineIn.Stations[i].Id == stationInDb.Id)
                    {
                        lineIn.Stations[i].StationName = stationInDb.StationName;
                        lineIn.Stations[i].NumberOnLine = stationInDb.NumberOnLine;
                    }
                }
                _lineBll.UpdateLine(lineIn);
                
                ViewBag.line = lineIn;            
                return View();
        }
        
        
        public ActionResult DeleteStation(int id)
        {
            Console.WriteLine(id + "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            _stationBll.DeleteStation(id);
            return RedirectToAction("Admin", "Admin");
        }

        public ActionResult AddPT()
        {
            var pt = new RepositoryModelPassengerType();
            return View("EditPassengerType", pt);
        }

        public ActionResult EditPassengerType(int id)
        {
            var Type = _passengerTypeBll.GetPassengerTypeTypeById(id);
            return View(Type);
        }

        [HttpPost]
        public ActionResult EditPassengerType(RepositoryModelPassengerType type)
        {
            if (ModelState.IsValid)
            {
                if (type.Id != 0)
                {
                    _passengerTypeBll.UpdatePt(type.Id, type);
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    _passengerTypeBll.AddPT(type);
                    return RedirectToAction("Admin", "Admin");
                }
            }

            return View();
        }

        public ActionResult DeletePT(int id)
        {
            _passengerTypeBll.DeletePT(id);
            return RedirectToAction("Admin", "Admin");
        }

        //ADD
        public ActionResult AddDeparture()
        {
            var departure = new RepositoryModelDepartures();
            return View("EditDeparture");
        }

        //EDIT
        public ActionResult EditDeparture(int id)
        {
            var departure = _departureBll.GetDepartureById(id);
            return View(departure);
        }

        //ADD+EDIT POST
        [HttpPost]
        public ActionResult EditDeparture(RepositoryModelDepartures departure)
        {
            if (ModelState.IsValid)
            {
                if (departure.Id != 0)
                {
                    _departureBll.UpdateDeparture(departure.Id, departure);
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    _departureBll.AddDeparture(departure);
                    return RedirectToAction("Admin", "Admin");
                }
            }

            return View();
        }

        public ActionResult DeleteDeparture(int id)
        {
            _departureBll.DeleteDeparture(id);
            return RedirectToAction("Admin", "Admin");
        }
    }
}