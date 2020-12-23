﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context = null;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
       
        //POST api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");
                
                movie.NumberAvailable--;                
                var rentalObj = new Rental(){
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rentalObj);                
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
