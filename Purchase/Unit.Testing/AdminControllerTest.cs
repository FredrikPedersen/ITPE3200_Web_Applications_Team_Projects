using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using MVC.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories;
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

        }
    }
}