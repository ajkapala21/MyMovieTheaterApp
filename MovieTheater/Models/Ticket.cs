using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string SeatName { get; set; }

        public Viewing Viewing { get; set; }

        [Required]
        public int ViewingId { get; set; }

        public string UserId { get; set; }

        public Ticket(Seat s, int v)
        {
            SeatName = s.Name;
            ViewingId = v;
        }
        public Ticket()
        {

        }
    }
}