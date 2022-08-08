using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieTheater.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Length { get; set; } //in minutes

        [Display(Name = "Upload File")]
        public string ImagePath { get; set; }
    }
}