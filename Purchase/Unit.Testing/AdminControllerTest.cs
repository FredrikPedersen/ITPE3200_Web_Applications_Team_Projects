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
                new LineBLL(new LineRepositoryStub()));
        }

        [Test]
        public void show_Admin_View()
        {

            var model = new AdminModel
            {
                Stations = _controller._stationBll.GetAllStations(),
                Departures = _controller._departureBll.GetAllDepartures(),
                Lines = _controller._lineBll.GetAllLines()
            };

            var viewResult = (ViewResult) _controller.Admin();
            var resultModel = (AdminModel) viewResult.Model;
            
            Assert.AreEqual(viewResult.ViewName, null);
            Assert.AreEqual(model.Departures.Count, resultModel.Departures.Count);
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
            
            var viewResult = (ViewResult) _controller.AddStation(id);
            var resultModel = (AdminModel) viewResult.Model;

            Assert.AreEqual(viewResult.ViewName, null);
            Assert.AreEqual(model.Line.Id, resultModel.Line.Id);
            
        }

        [Test]
        public void AddStation_Post()
        {
            var model = new AdminModel
            {
                Line = _controller._lineBll.GetLineById(123),
                Station = _controller._stationBll.GetStationById(1)
            };
            
            var viewResult = (ViewResult) _controller.AddStation(model);
            
            Assert.AreEqual(viewResult.ViewName, null);

        }

        [Test]
        public void show_EditStation_View()
        {
            var viewResult = (ViewResult) _controller.EditStation(1,1);
            Assert.AreEqual(viewResult.ViewName, null);

        }

        [Test]
        public void EditStation_Post()
        {
            var model = new AdminModel
            {
                Line = _controller._lineBll.GetLineById(123),
                Station = _controller._stationBll.GetStationById(1)
            };
            var viewResult = (ViewResult) _controller.EditStation(model);
            Assert.AreEqual(viewResult.ViewName, null);
        }

        [Test]
        public void DeleteStation()
        {
            var viewResult = (ViewResult) _controller.DeleteStation(1,123);
            Assert.AreEqual(viewResult.ViewName, "EditLine");
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
        public void EditDeparture_post_Ok_id1()
        {
            var type = _controller._departureBll.GetDepartureById(1);
            var viewResult = (RedirectToActionResult) _controller.EditDeparture(type);
            Assert.AreEqual(viewResult.ActionName, "Admin");
            
        }
        [Test]
        public void EditDeparture_post_Ok_id0()
        {
            var type = new RepositoryModelDepartures() {Id = 0, DepartureTime = "15:00"};
            var viewResult = (RedirectToActionResult) _controller.EditDeparture(type);
            Assert.AreEqual(viewResult.ActionName, "Admin");
            
        }

        [Test]
        public void DeleteDeparture()
        {
            var viewResult = (RedirectToActionResult) _controller.DeleteDeparture(1);
            Assert.AreEqual(viewResult.ActionName, "Admin");
        }

    }
}