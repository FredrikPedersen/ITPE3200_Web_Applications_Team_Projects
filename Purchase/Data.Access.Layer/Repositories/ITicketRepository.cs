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

        //Statiske metoder går ikke an å ha i interface?
        //TODO må denne her? static DateTime StringsToDateTime(String date, String time);
        //TODO static string SeparateGivenName(string name)
        //TODO string SeparateLastName(string name);
        //TODO double GeneratePrice(DbStation fromStation, DbStation toStation, DbPassengerType passengerType);

        DbCustomer CreateNewCustomerFromInput(RepositoryModelTicket ticket);

        DbPassengerType FindTicketPassengerType(string passengerTypeName);

        List<DbPassengerType> GetAllPassengerTypes();
    }
}