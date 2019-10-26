using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using MVC.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Model.RepositoryModels;
using Model.ViewModels;

namespace Unit.Testing
{
    
    public class AdminControllerTest
    {
        private AdminController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new AdminController(new DepartureBLL(new DepartureRepositoryStub()), new StationBLL(new StationRepositoryStub()),
                new TicketBLL(new TicketRepositoryStub()), new UserBLL(new UserRepositoryStub()), new PassengerTypeBLL(new PassengerTypeRepositoryStub()),
                new LineBLL(new LineRepositoryStub()));
        }

        [Test]
        public void show_Admin_View()
        {

            var model = new AdminModel
            {
                Stations = _controller._stationBll.GetAllStations(),
                Departures = _controller._departureBll.GetAllDepartures(),
                Types = _controller._passengerTypeBll.GetAllPt(),
                Lines = _controller._lineBll.GetAllLines()
            };

            var viewResult = (ViewResult) _controller.Admin();
            var resultModel = (AdminModel) viewResult.Model;
            
            Assert.AreEqual(viewResult.ViewName, null);
            Assert.AreEqual(model.Departures.Count, resultModel.Departures.Count);
            Assert.AreEqual(model.Types.Count, resultModel.Types.Count);
            Assert.AreEqual(model.Lines.Count, resultModel.Lines.Count);
            Assert.AreEqual(model.Stations.Count, resultModel.Stations.Count);

        }


        [Test]
        public void show_EditLine_View()
        {
            var id = 123;
            var model = new AdminModel
            {
                Line = _controller._lineBll.GetLineById(id)
            };
            
            var viewResult = (ViewResult) _controller.EditLine(id);
            var resultModel = (AdminModel) viewResult.Model;

            Assert.AreEqual(viewResult.ViewName, null);
            Assert.AreEqual(model.Line.Id, resultModel.Line.Id);
            
        }

        [Test]
        public void show_AddStation_View()
        {
            var id = 123;
            var model = new AdminModel
            {
                Line = _controller._lineBll.GetLineById(id)
            };
            
            var viewResult = (ViewResult) _controller.EditLine(id);
            var resultModel = (AdminModel) viewResult.Model;

            Assert.AreEqual(viewResult.ViewName, null);
            Assert.AreEqual(model.Line.Id, resultModel.Line.Id);
            
        }

        [Test]
        public void AddStation_Post()
        {
            var id = 123;
            var model = new AdminModel
            {
                Line = _controller._lineBll.GetLineById(id),
                Station = _controller._stationBll.GetStationById(1)
            };
            
            var viewResult = (ViewResult) _controller.AddStation(model);
            
            Assert.AreEqual(viewResult.ViewName, null);

        }

        [Test]
        public void DeleteStation()
        {
            var viewResult = (RedirectToActionResult) _controller.DeleteStation(1);
            Assert.AreEqual(viewResult.ActionName, "Admin");
        }
        
        [Test]
        public void AddPT_show_EditPassengerType_View()
        {
            var viewResult = (ViewResult) _controller.AddPT();
            Assert.AreEqual(viewResult.ViewName, "EditPassengerType");
        }

        [Test]
        public void show_EditPassengerType_View()
        {
            var viewResult = (ViewResult) _controller.EditPassengerType(1);
            Assert.AreEqual(viewResult.ViewName, null);

        }

        [Test]
        public void EditPassengerType_post_Ok()
        {
            var type = _controller._passengerTypeBll.GetPassengerTypeTypeById(1);
            var viewResult = (RedirectToActionResult) _controller.EditPassengerType(type);
            Assert.AreEqual(viewResult.ActionName, "Admin");
            
        }
        
        [Test]
        public void EditPassengerType_post_Fail()
        {
            var type = new RepositoryModelPassengerType();
            _controller.ViewData.ModelState.AddModelError("Type", "No type name");
            var viewResult = (ViewResult) _controller.EditPassengerType(type);
            Assert.AreEqual(viewResult.ViewName, null);
            
        }

        [Test]
        public void DeletePT()
        {
            var viewResult = (RedirectToActionResult) _controller.DeletePT(1);
            Assert.AreEqual(viewResult.ActionName, "Admin");
        }

        [Test]
        public void AddDeparture_show_EditDeparture_View()
        {
            var viewResult = (ViewResult) _controller.AddDeparture();
            Assert.AreEqual(viewResult.ViewName, "EditDeparture");
        }
        
        [Test]
        public void show_EditDeparture_View()
        {
            var viewResult = (ViewResult) _controller.EditDeparture(1);
            Assert.AreEqual(viewResult.ViewName, null);

        }
        
        [Test]
        public void EditDeparture_post_Ok()
        {
            var type = _controller._departureBll.GetDepartureById(1);
            var viewResult = (RedirectToActionResult) _controller.EditDeparture(type);
            Assert.AreEqual(viewResult.ActionName, "Admin");
            
        }
        
        [Test]
        public void EditDeparture_post_Fail()
        {
            var type = new RepositoryModelPassengerType();
            _controller.ViewData.ModelState.AddModelError("DepartureTime", "No departure time");
            var viewResult = (ViewResult) _controller.EditPassengerType(type);
            Assert.AreEqual(viewResult.ViewName, null);
            
        }

        [Test]
        public void DeleteDeparture()
        {
            var viewResult = (RedirectToActionResult) _controller.DeleteDeparture(1);
            Assert.AreEqual(viewResult.ActionName, "Admin");
        }

    }
}