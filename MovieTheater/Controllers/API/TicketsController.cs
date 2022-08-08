using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using MovieTheater.Dtos;
using MovieTheater.Models;
using AutoMapper;
using System.Data.Entity;

namespace MovieTheater.Controllers.API
{
    public class TicketsController : ApiController
    {
        private ApplicationDbContext _context;

        public TicketsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<TicketDto> GetTicketsOwnedByUser(string id)
        {
            var ticketsQuery = _context.Tickets
                .Include(t => t.Viewing)
                .Include(t => t.Viewing.Movie)
                .Include(t => t.Viewing.Theater)
                .Where(t => t.UserId == id);

            return ticketsQuery
                .ToList()
                .Select(Mapper.Map<Ticket, TicketDto>);
        }
    }
}
