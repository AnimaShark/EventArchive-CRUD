namespace MVC_Booking_App.Migrations
{
    using MVC_Booking_App.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Booking_App.Models.RSVPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_Booking_App.Models.RSVPDbContext context)
        {
            context.Events.AddOrUpdate(i => i.EventName,
                new RSVP
                {
                    EventName = "Animangaki",
                    Date = DateTime.Parse("2026-5-20"),
                    Genre = "Romantic Comedy",
                    TicketQuota = 45000,
                    Price = 50
                },

                 new RSVP
                 {
                     EventName = "Animefest",
                     Date = DateTime.Parse("2026-4-19"),
                     Genre = "Anime",
                     TicketQuota = 120000,
                     Price = 55
                 },

                 new RSVP
                 {
                     EventName = "ComicFiesta",
                     Date = DateTime.Parse("2025-12-18"),
                     Genre = "Japan",
                     TicketQuota = 200000,
                     Price = 65
                 },

               new RSVP
               {
                   EventName = "Con-nichiwa",
                   Date = DateTime.Parse("2025-6-6"),
                   Genre = "Anime",
                   TicketQuota = 35000,
                   Price = 29
               }
           );

        }
    }
}
