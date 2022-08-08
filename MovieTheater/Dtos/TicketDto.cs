using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }

        [Required]
        public string SeatName { get; set; }

        public ViewingDto Viewing { get; set; }

        [Required]
        public int ViewingId { get; set; }

        public string UserId { get; set; }
    }
}