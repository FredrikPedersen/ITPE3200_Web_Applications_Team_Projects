using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using MVC.Controllers;
using NUnit.Framework;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace Unit.Testing
{
    public class TicketControllerTest
    {
        private TicketController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new TicketController(new TicketBLL(new TicketRepositoryStub()));
        }

        [Test]
        public void Ticket_ReturnsAViewResult()
        {
            var result = (ViewResult) _controller.Ticket();
            
            Assert.AreEqual(result.ViewName, null);
        }
    }
}