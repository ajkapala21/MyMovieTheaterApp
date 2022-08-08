using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieTheater.Models;
using MovieTheater.ViewModels;

namespace MovieTheater.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
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
            var viewModel = new MovieFormViewModel(new Movie());
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageSite)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie);
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageSite)]
        public ActionResult Save(MovieFormViewModel movieFormViewModel)
        {
            Movie movie = new Movie();
            movie.Id = (int)movieFormViewModel.Id;
            movie.Length = movieFormViewModel.Length;
            movie.Name = movieFormViewModel.Name;
            movie.ImagePath = movie.ImagePath;

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie);
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                setUpImage(movie, movieFormViewModel.ImageFile);
                _context.Movies.Add(movie);
                
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                setUpImage(movie, movieFormViewModel.ImageFile);
                //or Mapper.Map(customer, customerInDB) combines all same named values they contain.
                movieInDb.ImagePath = movie.ImagePath;
                movieInDb.Name = movie.Name;
                movieInDb.Length = movie.Length;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult ViewingList(Movie movie)
        {
            return View();
        }
        public void setUpImage(Movie movie, HttpPostedFileBase ImageFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            movie.ImagePath = "Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            ImageFile.SaveAs(fileName);
        }
    }
}