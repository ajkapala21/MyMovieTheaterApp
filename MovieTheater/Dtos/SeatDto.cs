using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieTheater.Dtos;

namespace MovieTheater.Dtos
{
    public class SeatDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Taken { get; set; }

        public ViewingDto viewing { get; set; }

        public int ViewingId { get; set; }
    }
}