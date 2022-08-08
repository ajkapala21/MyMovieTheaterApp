using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTheater.Models;
using MovieTheater.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieTheater.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Checkout(int id)
        {
            var order = _context.Orders
                .Include(o => o.Seats)
                .SingleOrDefault(o => o.Id == id);
            var viewingId = order.Seats[0].ViewingId;
            var viewModel = new CheckoutViewModel {
                Order = order,
                Viewing = _context.Viewings
                .Include(v => v.Movie)
                .Include(v => v.Theater)
                .SingleOrDefault(v => v.Id == viewingId)
            };

            return View(viewModel);
        }

        public ActionResult BuySeats(CheckoutViewModel viewModel)
        {
            Viewing viewing = viewModel.Viewing;
            Order order = _context.Orders.Include(o => o.Seats)
                .SingleOrDefault(o => o.Id == viewModel.Order.Id);

            var userId = User.Identity.GetUserId();

            foreach (Seat seat in order.Seats)
            {
                Seat seatInDb = _context.Seats.SingleOrDefault(s => s.Id == seat.Id);
                if (seatInDb.Taken == false)
                {
                    Ticket t = new Ticket(seat, viewing.Id);
                    t.UserId = userId;
                    _context.Tickets.Add(t);
                    seatInDb.Taken = true;
                }
                else
                {
                    return RedirectToAction("Error", "Tickets");
                }
            }
            checkIfSoldOut(viewing);
            _context.SaveChanges();
            return RedirectToAction("Index", "Tickets");
        }
        private void checkIfSoldOut(Viewing viewing)
        {
            var viewingInDb = _context.Viewings.SingleOrDefault(v => v.Id == viewing.Id);
            var seatsForViewing = _context.Seats.Where(s => s.ViewingId == viewing.Id);
            foreach(Seat s in seatsForViewing)
            {
                if (s.Taken == false)
                {
                    return;
                }
            }
            viewingInDb.SoldOut = true;
            _context.SaveChanges();
        }
    }
}