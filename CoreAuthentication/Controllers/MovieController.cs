using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAuthentication.CustomValidators;
using CoreAuthentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAuthentication.Controllers
{
    public class MovieController : Controller
    {

        [HttpGet]
        public IActionResult Add()
        {
            MovieVM val = new MovieVM();

            Movie moviea = new Movie();
            moviea.Description = "sastry";
            moviea.Email = "x@x.com";
            moviea.Genre = Genre.Classic;
            moviea.Id = 1;
            moviea.Price = 100;
            moviea.Title = "sastry";
            moviea.ReleaseDate = DateTime.Now.Date;
            moviea.StartDate = DateTime.Parse("01/01/1974");
            moviea.EndDate= DateTime.Parse("01/01/1984");

            val.MovieLst = MovieVM.getMoviesAsSelectListItems();
            val.Movie = moviea;

            ViewBag.MovieLst = MovieVM.getMoviesAsSelectListItems();
            return View(val.Movie);
        }

        [HttpPost]
        public IActionResult Add(Movie s)
        {
            bool b = ModelState.IsValid;
            return View(s);
        }
        //[Produces("text/html")]
        //public string PlainHtml()
        //{
        //    return "AddHtml.html";
        //}

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string Email)
        {


            if (Email == "x@x.com")
            {
                return Json($"Email {Email} is already in use.");
            }

            return Json(true);
        }
    }
}