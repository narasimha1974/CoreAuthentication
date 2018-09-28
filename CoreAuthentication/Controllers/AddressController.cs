using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryHelperInterfaces;

namespace CoreAuthentication.Controllers
{
    public class AddressController : Controller
    {
       // ICRUDCountry _crudCountry = null;
        aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = null;

        public AddressController(ICRUDCountry crudCountry, aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context xv )
        {
            //_crudCountry = crudCountry;
            _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = xv;
        }
        public IActionResult ShowCountries()
        {
            IEnumerable<Country> countries = null;
            ReturnCountries(out countries);
            return View(countries);
        }
        

        [HttpGet]
        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(string Name)
        {
           // _crudCountry.Create(Name);
            _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.Country.Add(new Country() {Id= Guid.NewGuid().ToString(), Name = Name });
            _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.SaveChanges();

            IEnumerable<Country> countries = null;
            ReturnCountries(out countries);
         
            return View("ShowCountries", countries);
        }

        public IActionResult AddState()
        {
            VMState vMState = new VMState();
            IEnumerable<Country> countries = null;
            vMState.Countries = ReturnCountries(out countries);

            ViewData.Model = vMState;
            return View();
        }

        private List<SelectListItem> ReturnCountries(out IEnumerable<Country> countries)
        {
            List<SelectListItem> xList = new List<SelectListItem>();
            List<Country> countriesList = new List<Country>();
            foreach (var x in _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.Country)
            {
                xList.Add(new SelectListItem() { Text = x.Name, Value = x.Id, Selected = false });
                countriesList.Add(new Country() { Id = x.Id, Name = x.Name });
            }
            countries = countriesList.AsEnumerable();

            return xList;

        }

        [HttpPost]
        public IActionResult AddState(VMState state)
        {

            State stateData = new State();
            stateData.CountryId = state.CountryId;
            string selectedCountry = HttpContext.Request.Form["CountryId"].ToString();
            stateData.Id = Guid.NewGuid().ToString();
            stateData.Name = state.Name;            
            _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.State.Add(stateData);
            _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.SaveChanges();


            return View("AddState", state);
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