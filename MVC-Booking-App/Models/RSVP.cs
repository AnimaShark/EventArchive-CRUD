using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVC_Booking_App.Models
{
    public class RSVP
    {
        public int ID { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string EventName { get; set; }

        [Display(Name = "Starting Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required, StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 2000), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(1, 1000000)]
        public int TicketQuota { get; set; }
    }
    public class RSVPDbContext : DbContext
    {
        public DbSet<RSVP> Events { get; set; }
    }
}