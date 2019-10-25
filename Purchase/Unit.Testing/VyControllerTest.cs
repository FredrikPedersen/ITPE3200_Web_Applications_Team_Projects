using Business.Logic.Layer;
using Data.Access.Layer.Repositories.Stubs;
using MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Unit.Testing
{
    public class VyControllerTest
    {
        public void show_Index_HttpPost_View()
        {
            var controller = new VyController(new TicketBLL(new TicketRepositoryStub()), new StationBLL(new StationRepositoryStub()),
                new DepartureBLL(new DepartureRepositoryStub()), new UserBLL(new UserRepositoryStub()));
        }
    }
}