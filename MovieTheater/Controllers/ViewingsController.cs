using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTheater.Models;
using MovieTheater.ViewModels;
using System.Data.Entity;

namespace MovieTheater.Controllers
{
    public class ViewingsController : Controller
    {
        private ApplicationDbContext _context;

        public ViewingsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Viewings
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageSite))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageSite)]
        public ActionResult New()
        {
            var movies = _context.Movies.ToList();
            var theaters = _context.Theaters.ToList();
            var viewModel = new ViewingFormViewModel()
            {
                Theaters = theaters,
                Movies = movies
            };
            return View("ViewingForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageSite)]
        public ActionResult Edit(int Id)
        {
            var viewing = _context.Viewings.SingleOrDefault(v => v.Id == Id);
            if (viewing == null)
            {
                return HttpNotFound();
            }

            var movies = _context.Movies.ToList();
            var theaters = _context.Theaters.ToList();
            var viewModel = new ViewingFormViewModel(viewing)
            {
                Theaters = theaters,
                Movies = movies
            };
            return View("ViewingForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageSite)]
        public ActionResult Save(Viewing viewing)
        {
            if (!ModelState.IsValid)
            {
                var movies = _context.Movies.ToList();
                var theaters = _context.Theaters.ToList();
                var viewModel = new ViewingFormViewModel(viewing)
                {
                    Theaters = theaters,
                    Movies = movies
                };
                return View("ViewingForm", viewModel);
            }
            if (viewing.Id == 0)
            {
                viewing.TimeStartOutput = String.Format("{0:dddd, dd MMMM yyyy HH:mm}", viewing.TimeStart);
                viewing.TimeEndOutput = String.Format("{0:dddd, dd MMMM yyyy HH:mm}", viewing.TimeEnd);
                viewing.SoldOut = false;
                _context.Viewings.Add(viewing);
                setupViewing(viewing);
            }
            else
            {
                var viewingInDb = _context.Viewings.SingleOrDefault(v => v.Id == viewing.Id);
                removeSeating(viewingInDb);
                setupViewing(viewingInDb);
                viewingInDb.SoldOut = false;
                viewingInDb.MovieId = viewing.MovieId;
                viewingInDb.TheaterId = viewing.TheaterId;
                viewingInDb.TimeStart = viewing.TimeStart;
                viewingInDb.TimeStartOutput = String.Format("{0:dddd, dd MMMM yyyy HH:mm}", viewing.TimeStart);
                viewingInDb.TimeEndOutput = String.Format("{0:dddd, dd MMMM yyyy HH:mm}", viewing.TimeEnd);
                viewingInDb.TimeEnd = viewing.TimeEnd;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Viewings");
        }

        public ActionResult ViewingList(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
        
        public ActionResult Seating(int Id)
        {
            var viewing = _context.Viewings
                .Include(v => v.Movie)
                .Include(v => v.Theater)
                .SingleOrDefault(v => v.Id == Id);
            return View(viewing);
        }

        private void setupViewing(Viewing viewing)
        {
            viewing.Movie = _context.Movies.SingleOrDefault(m => m.Id == viewing.MovieId);
            viewing.setName();
            viewing.Theater = _context.Theaters.SingleOrDefault(t => t.Id == viewing.TheaterId);
            setSeating(viewing);
        }

        private void setSeating(Viewing viewing)
        {
            
            for (int row = 0; row < viewing.Theater.SeatHeight; row++)
            {
                List<Seat> list = new List<Seat>();
                for (int col = 0; col < viewing.Theater.SeatWidth; col++)
                {
                    Seat s = new Seat();
                    s.Name = Number2String(row, true) + (col + 1);
                    s.Taken = false;
                    s.viewing = viewing;
                    s.ViewingId = viewing.Id;
                    _context.Seats.Add(s);
                }
            }
            _context.SaveChanges();
        }

        private void removeSeating(Viewing viewing)
        {
            var seats = _context.Seats.Where(s => s.ViewingId == viewing.Id).ToList();
            foreach(var s in seats)
            {
                _context.Seats.Remove(s);
            }
            _context.SaveChanges();
        }

        private string Number2String(int number, bool isCaps)
        {
            char c = (char)((isCaps ? 65 : 97) + (number));
            return c.ToString();
        }
    }
}