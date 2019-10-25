using Data.Access.Layer;
using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using Data.Access.Layer.Repositories;
using Data.Access.Layer.Repositories.Interfaces;
using Data.Access.Layer.Repositories.Repository;

namespace Business.Logic.Layer
{
    public class TicketBLL
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

        private DateTime StringsToDateTime(String date, String time)
        {
            return _ticketRepository.StringsToDateTime(date, time);
        }

        private string SeparateGivenName(string name)
        {
            return _ticketRepository.SeparateGivenName(name);
        }

        private string SeparateLastName(string name)
        {
            return _ticketRepository.SeparateLastName(name);
        }

        private double GeneratePrice(DbStation fromStation, DbStation toStation, DbPassengerType passengerType)
        {
            return _ticketRepository.GeneratePrice(fromStation, toStation, passengerType);
        }

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