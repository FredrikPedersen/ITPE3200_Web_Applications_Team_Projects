using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vy_TicketPurchase_Core.Repository.DBModels
{
    public class DbDepartures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Avgangstid")]
        //[DataType(DataType.Time)]
        public string departureTime { get; set; }

        //Kan potensielt legge inn stasjoner og linjer i tillegg her for å få egenspesifiserte avgangstider per stasjon ved utvidelse
        //Har en seedmetode som putter inn i databasen, kan endre til å seede inn fra fil
        //Departures er lagt inn i databasen, og oppdatert startup
        //Må lage metode i DepartureService klasse under business som henter ut kun billetter etter gitt tidspunkt
        //Trenger kun servicemodelDeparture for å redigere avganger i et eget view til innlevering 2
        //Fra forrige view, får inn en servicemodelticket, oppdaterer tid og dato verdiene og sender videre for å opprette objektet i kontrolleren.
    }
}