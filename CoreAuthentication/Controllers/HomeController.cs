using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAuthentication.Models;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

namespace CoreAuthentication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
         
        public HomeController()
        {
            
        }

        [Authorize( Roles = "Admin")]
        public IActionResult Index()
        {
           

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            string name = HttpContext.User.Identity.Name;
          
            return View();
        }
        [AllowAnonymous]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
