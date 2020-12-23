using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context = null;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDto =  moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDto);
        }
        //GET api/movies/1
        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            var movieDto = Mapper.Map<Movie, MovieDto>(movie);
            return Ok(movieDto);
        }
        //POST api/movies
        [HttpPost]
        [Authorize(Roles= RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumberAvailable = movie.NumberInStock;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //PUT api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int Id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            Mapper.Map(movieDto, movie);
            _context.SaveChanges();
            return Ok();
        }
        //DELETE api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int Id)
        {            
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
