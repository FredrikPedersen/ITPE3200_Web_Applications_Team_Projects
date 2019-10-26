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
            controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new DepartureBLL(new DepartureRepositoryStub()), new StationBLL(new StationRepositoryStub()), new UserBLL(new UserRepositoryStub()));
        }

        [Test]
        public void Show_Index_View()
        {
            var resultat = (ViewResult)controller.Index();
            Assert.AreEqual(resultat.ViewName, null);
        }

        [Test]
        public void Show_ToAdmin()
        {
            var result = (RedirectToActionResult)controller.ToAdmin();
            Assert.AreEqual(result.ActionName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Admin");
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
        public void Index_post()
        {
            var ticket = new RepositoryModelTicket()
            {
                Id = 1,
                FromStation = "Lillestrøm",
                ToStation = "Lillestrøm",
                ValidFromDate = "12.12.20",
                ValidFromTime = "10:30",
                Price = 100,
                CustomerGivenName = "Fornavn",
                CustomerLastName = "Etternavn",
                CustomerNumber = "99999999",
                PassengerType = "Type"
            };
            var result = (ViewResult)controller.Index(ticket);
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(result.ViewData.Values.First(), "SelectTrip");
        }

        [Test]
        public void Index_post_validationFail()
        {
            var ticket = new RepositoryModelTicket();
            controller.ViewData.ModelState.AddModelError("FraStasjon", "Ikke oppgitt frastasjon");
            var resultat = (ViewResult)controller.Index(ticket);

            Assert.IsTrue(resultat.ViewData.ModelState.Count == 1); //kan fikses med større eller lik 1 men vet ikk om det er riktig
            Assert.AreEqual(resultat.ViewName, null);
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
        public void SelectTrip_test()
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
            Assert.AreEqual(resultat.ActionName, "");
            Assert.AreEqual(resultat.RouteValues.Values.First(), "List");
        }

        [Test]
        public void TestAutocomplete()
        {
        }

        [Test]
        public void TestAutocompleteTo()
        {
        }

        [Test]
        public void GetPassengerTypesTest()
        {
        }

        [Test]
        public void GetStationsFromNamesTest()
        {
        }

        [Test]
        public void GetPassengersForDropDownTest()
        {
        }

        [Test]
        public void RegisterTest()
        {
            var resultat = (ViewResult)controller.Register();
            Assert.AreEqual(resultat.ViewName, null);
        }

        public void RegisterPostTest()
        {
        }
    }
}