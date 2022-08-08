using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Theater
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte SeatWidth { get; set; }

        [Required]
        public byte SeatHeight { get; set; }
    }
}