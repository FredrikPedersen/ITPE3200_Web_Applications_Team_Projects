using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DBDepartures
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public string departureDate { get; set; }

        [DataType(DataType.Time)]
        public string departureTime { get; set; }

        //Kan potensielt legge inn stasjoner og linjer i tillegg her for å få egenspesifiserte avgangstider per stasjon ved utvidelse
        //Trenger en seedmetode som putter avganger inn i databasen
        //Må legge inn departures som en tabell i databasen
        //Hente ut alle filer i avgangdatabasen til avganger med knapp for å velge avgang, som er etter valgt tidspunkt( metode i ny DepartureService klasse under business)
        //Trenger kun servicemodelDeparture for å redigere avganger i et eget view til innlevering 2
        //Fra forrige view, får inn en servicemodelticket, oppdaterer tid og dato verdiene og sender videre for å opprette objektet i kontrolleren.
    }
}