using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieTheater.Models;

namespace MovieTheater.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Length { get; set; } //in minutes
        
        [Display(Name = "Upload File")]
        public string ImagePath { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }
                return "New Movie";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
                Id = movie.Id;
                Name = movie.Name;
                Length = movie.Length;
        }
    }
}