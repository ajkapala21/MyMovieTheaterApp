using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MovieTheater.Models;
using MovieTheater.Dtos;

namespace MovieTheater.Dtos
{
    public class ViewingDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public MovieDto Movie { get; set; }

        [Required]
        public int MovieId { get; set; }

        public TheaterDto Theater { get; set; }

        [Required]
        [Display(Name = "Theater Name")]
        public byte TheaterId { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        public string TimeStartOutput { get; set; }

        [Required]
        public DateTime TimeEnd { get; set; }

        public string TimeEndOutput { get; set; }

        public bool SoldOut { get; set; }

        public List<List<Seat>> Seats { get; set; }
    }
}