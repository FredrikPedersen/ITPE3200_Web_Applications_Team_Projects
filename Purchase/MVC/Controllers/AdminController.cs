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
        
        public readonly DepartureBLL _departureBll;
        public readonly StationBLL _stationBll;
        public readonly LineBLL _lineBll;


        public AdminController(DepartureBLL departureBll, StationBLL stationBll, LineBLL lineBll)
        {
            _departureBll = departureBll;
            _stationBll = stationBll;
            _lineBll = lineBll;
        }

        public ActionResult Admin()
        {
            
            var model = new AdminModel()
            {
                Stations = _stationBll.GetAllStations(),
                Departures = _departureBll.GetAllDepartures(),
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
            
                _stationBll.UpdateStation(stationIn.Id, stationIn);
                
                
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
        
        
        public ActionResult DeleteStation(int id, int line)
        {
            _stationBll.DeleteStation(id);
            
            var model = new AdminModel()
            {
                Line = _lineBll.GetLineById(line)
            };
            
            ViewBag.line = _lineBll.GetLineById(line);
            
            return View("EditLine", model);
        }

        //ADD
        public ActionResult AddDeparture()
        {
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
            if (!ModelState.IsValid) return View();
            if (departure.Id != 0)
            {
                _departureBll.UpdateDeparture(departure.Id, departure);
                return RedirectToAction("Admin", "Admin");
            }
            _departureBll.AddDeparture(departure);
            return RedirectToAction("Admin", "Admin");
        }

        public ActionResult DeleteDeparture(int id)
        {
            _departureBll.DeleteDeparture(id);
            return RedirectToAction("Admin", "Admin");
        }
    }
}