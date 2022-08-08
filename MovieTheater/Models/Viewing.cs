using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Viewing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Movie Movie { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        public Theater Theater { get; set; }

        [Required]
        [Display(Name = "Theater Name")]
        public byte TheaterId { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime TimeStart { get; set; }

        public string TimeStartOutput { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime TimeEnd { get; set; }

        public string TimeEndOutput { get; set; }

        public bool SoldOut { get; set; }

        public void setName()
        {
            if (Movie != null)
            {
                Name = Movie.Name;
            }
            Name = Movie.Name;
        }
    }
}