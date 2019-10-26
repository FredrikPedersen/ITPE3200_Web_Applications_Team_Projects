using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using MVC.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories;

namespace Unit.Testing
{
    public class AdminControllerTest
    {
        private AdminController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new AdminController(new DepartureBLL(new DepartureRepositoryStub()), new StationBLL(new StationRepositoryStub()),
                new TicketBLL(new TicketRepositoryStub()), new UserBLL(new UserRepositoryStub()), new PassengerTypeBLL(new PassengerTypeRepositoryStub()),
                new LineBLL(new LineRepositoryStub()));
        }

        [Test]
        public void testNoe()
        {
        }
    }
}