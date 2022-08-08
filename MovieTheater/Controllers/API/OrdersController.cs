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
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateOrder(List<int> list)
        {
            Order order = new Order();
            foreach(int num in list)
            {
                order.Seats.Add(_context.Seats
                    .Include(s => s.viewing)
                    .SingleOrDefault(s => s.Id == num));
            }
            _context.Orders.Add(order);

            _context.SaveChanges();

            
            return Created(new Uri(Request.RequestUri + "/" + order.Id), order);
        }
    }
}
