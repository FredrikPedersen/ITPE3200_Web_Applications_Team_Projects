using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using MVC.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit.Testing
{
    public class ListControllerTest
    {
        private ListController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new ListController(new TicketBLL(new TicketRepositoryStub()));
        }

        [Test]
        public void testNoe()
        {
        }
    }
}