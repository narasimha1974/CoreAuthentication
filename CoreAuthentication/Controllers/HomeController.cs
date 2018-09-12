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
        UserManager<IdentityUser> _userManager = null;
        public HomeController(UserManager<IdentityUser> UserManager)
        {
            _userManager = UserManager;
        }

        [Authorize(Policy = "Top2ManagerOnly")]
        public IActionResult Index()
        {
            foreach (Claim claim in HttpContext.User.Claims)
            {

                // Write out each claim type, claim value, and the right. There are two
                // possible values for the right: "identity" and "possessproperty". 
                string str = ""; ;
                
                str+="Claim Type = {0}"+ claim.Type;
                str+= "\t Resource = {0}"+ claim.Value;
                str+= "\t Right = {0}"+ claim.ValueType;

                
                
            }
            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";
            string userId = _userManager.GetUserId(this.User);
            //cannot convert from System.Security.Principal.Identity to Microsoft.AspNetCore.Identity.IdentityUser
            IdentityUser xiu = null;
            foreach (IdentityUser use in _userManager.Users)
            {
                if (use.Email == this.User.Identity.Name)
                {
                    xiu = use;
                }
            }
            IList<String> xi = await _userManager.GetRolesAsync(xiu);
            var x = this.User;

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
