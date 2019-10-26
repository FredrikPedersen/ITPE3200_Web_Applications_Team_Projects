using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DBModels;
using Model.RepositoryModels;
using MVC.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Utilities.Passwords;

namespace Unit.Testing
{
    public class VyControllerTest
    {
        private VyController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new DepartureBLL(new DepartureRepositoryStub()), new StationBLL(new StationRepositoryStub()), new UserBLL(new UserRepositoryStub()));
        }

        //Har problemer med å teste metoder som bruker HttpContext i controlleren
        //Har foreløpig ikke funnet en løsning på dette
        /*[Test]
        public void Show_Index_View()
        {
            var result = (Microsoft.AspNetCore.Mvc.ViewResult)controller.Index();
            Assert.AreEqual(result.ViewName, null);
        }*/

        /*[Test]
        public void Show_ToAdmin()
        {
            var result = (RedirectToActionResult)controller.ToAdmin();
            Assert.AreEqual(result.ActionName, "Index");
        }

        //More tests for toAdmins ifstatements

        [Test]
        public void LogIn_test()
        {
            var user = new RepositoryModelUser();
            user.UserName = "uName";
            user.Password = "pass";
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
        }*/

        [Test]
        public void Index_post()
        {
            var ticket = new RepositoryModelTicket()
            {
                Id = 1,
                FromStation = "Oslo S",
                ToStation = "Lillestrøm",
                ValidFromDate = "12.12.20",
                ValidFromTime = "10:30",
                Price = 100,
                CustomerGivenName = "Fornavn",
                CustomerLastName = "Etternavn",
                CustomerNumber = "99999999",
                PassengerType = "Adult"
            };
            var result = (ViewResult)controller.Index(ticket);
            Assert.AreEqual(result.ViewData.Values.First(), ticket);
        }

        [Test]
        public void Index_post_validationFail()
        {
            var ticket = new RepositoryModelTicket();
            controller.ModelState.AddModelError("test", "test");
            var result = (ViewResult)controller.Index(ticket);

            Assert.AreEqual(result.ViewData.Values.FirstOrDefault(), null);
        }

        [Test]
        public void Index_invalidStations()
        {
            RepositoryModelTicket ticket = new RepositoryModelTicket();
            ticket.ToStation = "bnjm";
            ticket.FromStation = "fghj";
            var result = (ViewResult)controller.Index(ticket);
            Assert.AreEqual(result.ViewName, null);
        }

        [Test]
        public void SelectTrip_test_post()
        {
            var ticket = new RepositoryModelTicket()
            {
                Id = 1,
                FromStation = "Oslo S",
                ToStation = "Lillestrøm",
                ValidFromDate = "12.12.20",
                ValidFromTime = "10:30",
                Price = 100,
                CustomerGivenName = "Fornavn",
                CustomerLastName = "Etternavn",
                CustomerNumber = "99999999",
                PassengerType = "Admin"
            };
            var resultat = (RedirectToActionResult)controller.SelectTrip(ticket);
            Assert.AreEqual(resultat.ActionName, "Ticket");
            Assert.AreEqual(resultat.RouteValues.Values.First(), 1);
        }

        [Test]
        public void TestAutocomplete()
        {
            string input = "Oslo S";
            JsonResult json = controller.Autocomplete(input);
            Assert.IsNotNull(json);
        }

        [Test]
        public void TestAutocompleteTo()
        {
            string input = "Oslo S";
            string from = "Lillestrøm";
            JsonResult json = controller.AutocompleteTo(input, from);
            Assert.IsNotNull(json);
        }

        [Test]
        public void GetStationsFromNamesTest()
        {
            string toStation = "Oslo S";
            string fromStation = "Lillestrøm";
            List<DbStation> list = controller.GetStationsFromNames(toStation, fromStation);
            Assert.AreEqual(toStation, list[0].StationName);
            Assert.AreEqual(fromStation, list[1].StationName);
        }

        [Test]
        public void test_getPassengertypes()
        {
            JsonResult json = controller.GetPassengerTypes();
            Assert.IsNotNull(json);
        }
    }
}