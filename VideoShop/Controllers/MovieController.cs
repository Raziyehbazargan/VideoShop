using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoShop.Models;
using VideoShop.ViewModels;
using System.Data.Entity;

namespace VideoShop.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel
            {               
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }
        // GET: Movie
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = _context.Movies.Include(g => g.GenreType);
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            Movie movie =  _context.Movies.Include(g => g.GenreType).FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Movies = _context.Movies.ToList(),
                Customers = _context.Customers.ToList()
            };

            return View();
        }

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.Single(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    GenreTypes = _context.GenreTypes.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                if (movieInDb == null)
                {
                    return HttpNotFound();
                }
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.InStock = movie.InStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
    }
}