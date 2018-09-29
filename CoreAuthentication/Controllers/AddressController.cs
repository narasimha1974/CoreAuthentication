using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAuthentication.Models;
using CoreAuthentication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CoreAuthentication.Controllers
{
    public class AddressController : Controller
    {        

        public AddressController()
        {
        }

       
        [HttpGet]
        public IActionResult Country()
        {
            
            CountryVM_DataManager countryVM_DataManager = new CountryVM_DataManager();
            return View(countryVM_DataManager.countryVM);
        }
        [HttpPost]
        public IActionResult Country(CountryVM countryVM)
        {
            CountryVM_DataManager countryVM_DataManager = new CountryVM_DataManager();
            countryVM_DataManager.SaveCountry(countryVM);
            return RedirectToAction("Country");                        
        }

        [HttpGet]
        public IActionResult State(string selectedCountryId = "")
        {
            StateVM_DataManager stateVM_DataManager = new StateVM_DataManager();
            stateVM_DataManager.SelectedCountryId = selectedCountryId;
            stateVM_DataManager.stateVM.countriesSLI = stateVM_DataManager.getCountriesAsSelectListItems();
            stateVM_DataManager.stateVM.stateSLI = stateVM_DataManager.getStatesAsSelectListItems();
            return View(stateVM_DataManager.stateVM);
        }
        [HttpPost]
        public IActionResult State(StateVM stateVM, string selectedCountryId, string selectedStateId)
        {
            StateVM_DataManager stateVM_DataManager = new StateVM_DataManager();
            stateVM_DataManager.SaveState(stateVM);
            return RedirectToAction("State");
        }
        [HttpGet]
        public IActionResult FetchStatesOfCountry(string selectedCountryId)
        {
            StateVM_DataManager stateVM_DataManager = new StateVM_DataManager();
            stateVM_DataManager.SelectedCountryId = selectedCountryId;
            stateVM_DataManager.stateVM.countriesSLI = stateVM_DataManager.getCountriesAsSelectListItems();
            stateVM_DataManager.stateVM.stateSLI = stateVM_DataManager.getStatesAsSelectListItems();
            return RedirectToAction("State",stateVM_DataManager.stateVM);

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