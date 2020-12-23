using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
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
            if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
            //var movieList = _context.Movies.Include(m => m.Genre).ToList(); 
            //return View(movieList);
        }
        public ActionResult MovieDetails(int id)
        {

            var movieList = _context.Movies.Include(m => m.Genre).ToList();
            var movie = movieList.Find(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genreList = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genreList               
            };
            return View("MovieForm",viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var genreList = _context.Genres.ToList();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genreList               
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {                   
                    Genres = _context.Genres.ToList()
                };            
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);                
            }
                
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
        
            return RedirectToAction("Index","Movies");
        }
    }


}