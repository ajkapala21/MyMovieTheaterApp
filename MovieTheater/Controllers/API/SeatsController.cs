using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieTheater.Dtos;
using MovieTheater.Models;
using AutoMapper;
using System.Data.Entity;

namespace MovieTheater.Controllers.API
{
    public class SeatsController : ApiController
    {
        private ApplicationDbContext _context;

        public SeatsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<SeatDto> GetSeatsForViewing(int id)
        {
            var seatsQuery = _context.Seats
                .Where(s => s.ViewingId == id);

            return seatsQuery
                .ToList()
                .Select(Mapper.Map<Seat, SeatDto>);
        }
    }
}
