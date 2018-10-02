using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAuthentication.CustomValidators;
using Microsoft.AspNetCore.Mvc;

namespace CoreAuthentication.Controllers
{
    public class MovieController : Controller
    {

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            return View();
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string email)
        {
            if (email=="x@x.com")
            {
                return Json($"Email {email} is already in use.");
            }

            return Json(true);
        }
    }
}