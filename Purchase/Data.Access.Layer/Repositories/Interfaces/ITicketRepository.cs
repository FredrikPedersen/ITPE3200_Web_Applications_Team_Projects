using Model.DBModels;
using Model.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Access.Layer
{
    public interface ITicketRepository
    {
        List<RepositoryModelTicket> GetAllTickets();

        bool SaveTicket(RepositoryModelTicket ticket, List<DbStation> stationsFromName);

        DateTime StringsToDateTime(String date, String time);

        string SeparateGivenName(string name);

        string SeparateLastName(string name);

        double GeneratePrice(DbStation fromStation, DbStation toStation, DbPassengerType passengerType);

        DbCustomer CreateNewCustomerFromInput(RepositoryModelTicket ticket);

        DbPassengerType FindTicketPassengerType(string passengerTypeName);

        List<DbPassengerType> GetAllPassengerTypes();
    }
}