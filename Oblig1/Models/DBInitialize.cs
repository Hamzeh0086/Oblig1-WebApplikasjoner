﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oblig1.Models
{
    public class DBInitialize
    {
        public static void Initialize(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            
            var context = serviceScope.ServiceProvider.GetService<KundeContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var poststed1 = new PostSteder { Postnr = "0010", Poststed = "Oslo" };
            var poststed2 = new PostSteder { Postnr = "0015", Poststed = "Oslo" };

            var ticket1 = new Ticket { Destination = "Oslo-kiel", TicketType = "En vei", TicketClass = "Business", AntallAdult = 2, AntallChild = 0, DepartureDato = "2021-11-23", ReturnDato =""};
            var ticket2 = new Ticket { Destination = "Stavenger-Oslo", TicketType = "Retur", TicketClass = "Economy", AntallAdult = 1, AntallChild = 1, DepartureDato = "2021-12-24", ReturnDato ="2023-01-03"};
            
            var kunde1 = new Kunder { Fornavn = "Tor", Etternavn = "Nordman", Telfonnr = "12345678", Epost = "xxx@oslomet.no", Adresse = "Pilestredet 35", PostSteder = poststed1, Ticket = ticket1};
            var kunde2 = new Kunder { Fornavn = "Morten", Etternavn = "Nordman", Telfonnr = "98765432", Epost = "zzz@oslomet.no", Adresse = "Pilestredet 32", PostSteder = poststed2, Ticket = ticket2};

         
            context.Kunder.Add(kunde1);
            context.Kunder.Add(kunde2);

            context.SaveChanges();
        }
    }
}
