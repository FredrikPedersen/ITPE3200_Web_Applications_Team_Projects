using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using Microsoft.AspNetCore.Mvc;
using Model.RepositoryModels;
using MVC.Controllers;
using NUnit.Framework;
using System.Linq;

namespace Unit.Testing
{
    public class VyControllerTest
    {
        public void show_Index_View()
        {
            var controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new StationBLL(new StationRepositoryStub()),
                new DepartureBLL(new DepartureRepositoryStub()), new UserBLL(new UserRepositoryStub()));
            var resultat = (ViewResult)controller.Index();
            Assert.AreEqual(resultat.ViewName, "");
        }

        public void show_toAdmin()
        {
            var controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new StationBLL(new StationRepositoryStub()),
                new DepartureBLL(new DepartureRepositoryStub()), new UserBLL(new UserRepositoryStub()));
            var result = (RedirectToRouteResult)controller.ToAdmin();
            Assert.AreEqual(result.RouteName, "");
        }

        public void LogIn_test()
        {
            var controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new StationBLL(new StationRepositoryStub()),
                          new DepartureBLL(new DepartureRepositoryStub()), new UserBLL(new UserRepositoryStub()));
            var user = new RepositoryModelUser()
            {
                UserName = "Brukernavn",
                Password = "Passord"
            };
            var result = (RedirectToRouteResult)controller.LogIn(user);
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Index");
        }
    }
}