using Data.Access.Layer;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic.Layer
{
    internal class TicketBLL
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketBLL(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<RepositoryModelTicket> GetAllTickets()
        {
            return _ticketRepository.GetAllTickets();
        }

        public bool SaveTicket(RepositoryModelTicket ticket, List<DbStation> stationsFromName)
        {
            return _ticketRepository.SaveTicket(ticket, stationsFromName);
        }

        //Må disse være med her?
        //TODO må denne her? static DateTime StringsToDateTime(String date, String time);
        //TODO static string SeparateGivenName(string name)
        //TODO string SeparateLastName(string name);
        //TODO double GeneratePrice(DbStation fromStation, DbStation toStation, DbPassengerType passengerType);

        public DbCustomer CreateNewCustomerFromInput(RepositoryModelTicket ticket)
        {
            return _ticketRepository.CreateNewCustomerFromInput(ticket);
        }

        public DbPassengerType FindTicketPassengerType(string passengerTypeName)
        {
            return _ticketRepository.FindTicketPassengerType(passengerTypeName);
        }

        public List<DbPassengerType> GetAllPassengerTypes()
        {
            return _ticketRepository.GetAllPassengerTypes();
        }
    }
}