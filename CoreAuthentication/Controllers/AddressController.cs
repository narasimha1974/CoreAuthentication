using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryHelperInterfaces;

namespace CoreAuthentication.Controllers
{
    public class AddressController : Controller
    {
        ICRUDCountry _crudCountry = null;

        public AddressController(ICRUDCountry crudCountry)
        {
            _crudCountry = crudCountry;
        }
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(string Name)
        {
            _crudCountry.Create(Name);
            return View("Index", _crudCountry.List());
        }
        public IActionResult AddState()
        {
            return View();
        }
        public IActionResult AddDistrict()
        {
            return View();
        }
        public IActionResult AddCity()
        {
            return View();
        }
    }
}