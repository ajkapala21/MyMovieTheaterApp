using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Taken { get; set; }

        public Viewing viewing { get; set; }

        public int ViewingId { get; set; }
    }
}