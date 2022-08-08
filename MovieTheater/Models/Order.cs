using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieTheater.Models
{
    public class Order
    {
        public int Id { get; set; }

        public List<Seat> Seats { get; set; }

        public Order()
        {
            Seats = new List<Seat>();
        }
    }
}