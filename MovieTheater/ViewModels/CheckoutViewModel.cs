using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieTheater.Models;

namespace MovieTheater.ViewModels
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; }

        public Viewing Viewing { get; set; }
    }
}