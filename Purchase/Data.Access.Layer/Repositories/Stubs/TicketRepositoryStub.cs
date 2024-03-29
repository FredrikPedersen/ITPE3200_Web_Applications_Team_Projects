﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Access.Layer.Repositories.Interfaces;
using Model.DBModels;
using Model.RepositoryModels;

namespace Data.Access.Layer.Repositories.Stubs
{
    public class TicketRepositoryStub : ITicketRepository
    {
        public TicketRepositoryStub()
        {
        }

        public DbCustomer CreateNewCustomerFromInput(RepositoryModelTicket ticket)
        {
            if (ticket == null) return null;
            return new DbCustomer
            {
                Name = ticket.CustomerGivenName + " " + ticket.CustomerLastName,
                Phonenumber = ticket.CustomerNumber
            };
        }

        public DbPassengerType FindTicketPassengerType(string passengerTypeName)
        {
            if (passengerTypeName.Equals("")) return null;
            var passengerTypes = GetAllPassengerTypes();

            foreach (var passengerType in passengerTypes)
            {
                if (passengerType.Type == passengerTypeName)
                {
                    return new DbPassengerType
                    {
                        PriceMultiplier = passengerType.PriceMultiplier,
                        Type = passengerType.Type
                    };
                }
            }
            return passengerTypes[0]; //This outcome should never happen, but sets passengerType to Adult if it does.
        }

        public double GeneratePrice(DbStation fromStation, DbStation toStation, DbPassengerType passengerType)
        {
            if (fromStation == null || toStation == null || passengerType == null) return 0;
            var start = fromStation.NumberOnLine;
            var end = toStation.NumberOnLine;
            var price = 0.0;
            if (start > end)
            {
                price = (start - end) * passengerType.PriceMultiplier;
            }
            else
            {
                price = (end - start) * passengerType.PriceMultiplier;
            }

            return price;
        }

        public List<DbPassengerType> GetAllPassengerTypes()
        {
            var list = new List<DbPassengerType>();
            var passengerType = new DbPassengerType
            {
                Id = 1,
                Type = "Adult",
                PriceMultiplier = 3.0
            };
            list.Add(passengerType);
            list.Add(passengerType);
            list.Add(passengerType);
            list.Add(passengerType);
            return list;
        }

        public List<RepositoryModelTicket> GetAllTickets()
        {
            var list = new List<RepositoryModelTicket>();
            var ticket = new RepositoryModelTicket
            {
                Id = 1,
                FromStation = "Frastasjon",
                ToStation = "TilStasjon",
                CustomerGivenName = "Navn",
                CustomerLastName = "Navn",
                CustomerNumber = "Nummer",
                ValidFromDate = "Dato",
                ValidFromTime = "Tid",
                Price = 40,
                PassengerType = "Type"
            };
            list.Add(ticket);
            list.Add(ticket);
            list.Add(ticket);
            return list;
        }

        public bool SaveTicket(RepositoryModelTicket ticket, List<DbStation> stationsFromName)
        {
            return ticket != null && stationsFromName != null;
        }

        public string SeparateGivenName(string name)
        {
            return name.Equals("") ? null : name;
        }

        public string SeparateLastName(string name)
        {
            return name.Equals("") ? null : name;
        }

        public DateTime StringsToDateTime(string date, string time)
        {
            var dateAndTime = date + " " + time;
            var timeDate = Convert.ToDateTime(dateAndTime);
            return Convert.ToDateTime(timeDate);
        }
    }
}