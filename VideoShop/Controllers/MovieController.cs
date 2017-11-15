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

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.GenreType);
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie =  _context.Movies.Include(g => g.GenreType).FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        /*private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id = 100, Name = "Friends"},
                new Movie {Id = 200, Name = "Fosters"},
            };
        }*/

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

    }
}