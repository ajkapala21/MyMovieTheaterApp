using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieTheater.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.ViewModels
{
    public class ViewingFormViewModel
    {
        public int? Id { get; set; }

        
        public string Name { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int? MovieId { get; set; }

        [Required]
        [Display(Name = "Theater Name")]
        public byte? TheaterId { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime? TimeStart { get; set; }

        [Required]
        [Display(Name = "Start End")]
        public DateTime? TimeEnd { get; set; }

        public IEnumerable<Theater> Theaters { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Viewing";
                }
                return "New Viewing";
            }
        }

        public ViewingFormViewModel()
        {
            Id = 0;
        }
        public ViewingFormViewModel(Viewing viewing)
        {
            Id = viewing.Id;
            Name = viewing.Name;
            MovieId = viewing.MovieId;
            TheaterId = viewing.TheaterId;
            TimeStart = viewing.TimeStart;
            TimeEnd = viewing.TimeEnd;
        }
    }
}