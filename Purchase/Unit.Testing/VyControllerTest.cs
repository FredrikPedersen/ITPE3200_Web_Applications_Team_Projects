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
        private VyController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new StationBLL(new StationRepositoryStub()),
                new DepartureBLL(new DepartureRepositoryStub()), new UserBLL(new UserRepositoryStub()));
        }

        [Test]
        public void show_Index_View()
        {
            var resultat = (ViewResult)controller.Index();
            Assert.AreEqual(resultat.ViewName, "");
        }

        [Test]
        public void show_toAdmin()
        {
            var result = (RedirectToRouteResult)controller.ToAdmin();
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Admin", "Admin");
        }

        //TODO teste om ifene i toAdmin blir kjørt, hvordan tvinge feil?
        /* [Test]
         public void show_ToAdmin_error()
         {
             var controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new StationBLL(new StationRepositoryStub()),
          new DepartureBLL(new DepartureRepositoryStub()), new UserBLL(new UserRepositoryStub()));
         }*/

        [Test]
        public void LogIn_test()
        {
            var user = new RepositoryModelUser()
            {
                UserName = "Brukernavn",
                Password = "Passord"
            };
            var result = (ViewResult)controller.LogIn(user);
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(result.ViewData.Values.First(), "Index");
        }

        [Test]
        public void LogIn_fail()
        {
            var user = new RepositoryModelUser();
            var result = (ViewResult)controller.LogIn(user);
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(result.ViewData.Values.First(), "Index");
        }

        [Test]
        public void index_post()
        {
            var ticket = new RepositoryModelTicket()
            {
                Id = 1,
                FromStation = "Frastasjon",
                ToStation = "TilStasjon",
                ValidFromDate = "12.12.20",
                ValidFromTime = "10:30",
                Price = 100,
                CustomerGivenName = "Fornavn",
                CustomerLastName = "Etternavn",
                CustomerNumber = "number",
                PassengerType = "Type"
            };
            var result = (ViewResult)controller.Index(ticket);
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(result.ViewData.Values.First(), "SelectTrip");
        }

        [Test]
        public void index_post_validationFail()
        {
            var ticket = new RepositoryModelTicket();
            controller.ViewData.ModelState.AddModelError("FraStasjon", "Ikke oppgitt frastasjon");
            var resultat = (ViewResult)controller.Index(ticket);

            Assert.IsTrue(resultat.ViewData.ModelState.Count == 1);
            Assert.AreEqual(resultat.ViewName, "");
        }

        [Test]
        public void index_invalidStations()
        {
            RepositoryModelTicket ticket = new RepositoryModelTicket();
            ticket.ToStation = "bnjm";
            ticket.FromStation = "fghj";
            var result = (ViewResult)controller.Index(ticket);
            Assert.AreEqual(result.ViewName, "");
        }

        [Test]
        public void selectTrip_test()
        {
            var ticket = new RepositoryModelTicket()
            {
                Id = 1,
                FromStation = "Frastasjon",
                ToStation = "TilStasjon",
                ValidFromDate = "12.12.20",
                ValidFromTime = "10:30",
                Price = 100,
                CustomerGivenName = "Fornavn",
                CustomerLastName = "Etternavn",
                CustomerNumber = "number",
                PassengerType = "Type"
            };
            var resultat = (RedirectToRouteResult)controller.SelectTrip(ticket);
            Assert.AreEqual(resultat.RouteName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "List");
        }

        [Test]
        public void TestTest()
        {
            string s1 = "Oslo S";
            string s2 = "Oslo S";
            Assert.AreEqual(s1, s2);
        }
    }
}