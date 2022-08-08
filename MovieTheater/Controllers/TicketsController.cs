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
    public class TicketsController : Controller
    {
        private ApplicationDbContext _context;

        public TicketsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var Id = User.Identity.GetUserId();

            var user = _context.Users
                .SingleOrDefault(u => u.Id == Id);
            return View("MyTickets", user);
        }

        public ActionResult Error()
        {
            return View("Error");
        }
    }
}