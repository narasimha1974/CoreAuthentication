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

namespace CoreAuthentication.Controllers
{
    public class HomeController : Controller
    {
        UserManager<IdentityUser> _userManager = null;
        RoleManager<IdentityRole> _roleManager = null;
        public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            bool IsAdmin = currentUser.IsInRole("Admin");
            var id = _userManager.GetUserId(User); // Get user id:
            string str = "";
            foreach (System.Security.Claims.Claim clm in currentUser.Claims)
            {
                str += clm.Value + " ";
            }

            return View();
        }
       

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            string name = HttpContext.User.Identity.Name;
          
            return View();
        }

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
