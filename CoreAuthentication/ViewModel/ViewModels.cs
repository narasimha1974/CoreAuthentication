using CoreAuthentication.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuthentication.ViewModel
{
    public class CountryVM
    {
        public Country country { get; set; }
        public IEnumerable<Country> countries { get; set; }
        public List<ModelStateDictionary> BusinessErrors { get; set; }

        public CountryVM()
        {
            countries = new List<Country>();
            BusinessErrors = new List<ModelStateDictionary>();
        }

    }

    public class StateVM
    {       
        public string state { get; set; }
        public string country { get; set; }
        public string selectedCountryId { get; set; }        
        public string selectedStateId { get; set; }
        public IEnumerable<Country> countries { get; set; }
        public IEnumerable<SelectListItem> countriesSLI { get; set; }
        public IEnumerable<SelectListItem> stateSLI { get; set; }
        public IEnumerable<State> statesOfThisCountry { get; set; }
    }

    public class VMDataManager
    {              
        public  string SelectedCountryId { get; set; }
        public  string SelectedStateId { get; set; }

      
        public  IEnumerable<SelectListItem> getCountriesAsSelectListItems()
        {
            List<SelectListItem> countries = new List<SelectListItem>();

            using (aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = new aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context())
            {
                foreach (Country cn in _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.Country)
                {
                    countries.Add(new SelectListItem() { Text = cn.Name, Value = cn.Id, Selected = (cn.Id == SelectedCountryId ? true : false) });
                }
            }

            return countries;
        }
        public IEnumerable<Country> getCountries()
        {
            List<Country> countries = new List<Country>();

            using (aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = new aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context())
            {
                foreach (Country cn in _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.Country.Where(rec => rec.Id != ""))
                {
                    countries.Add(new Country() { Id = cn.Id, Name = cn.Name });
                }
            }

            return countries;
        }
        public IEnumerable<SelectListItem> getStatesAsSelectListItems()
        {
            List<SelectListItem> states = new List<SelectListItem>();
            using (aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = new aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context())
            {
                foreach (State st in _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.State.Where(rec=>rec.CountryId ==SelectedCountryId))
                {
                    states.Add(new SelectListItem() { Text = st.Name, Value = st.Id, Selected = (st.Id == SelectedStateId ? true : false) });
                }
            }
            return states.AsEnumerable();
        }
        public IEnumerable<State> getStates()
        {
            List<State> states = new List<State>();
            using (aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = new aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context())
            {
                foreach (State st in _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.State.Where(rec => rec.CountryId == SelectedCountryId))
                {
                    states.Add(new State() { Id = st.Id, Name = st.Name, CountryId = st.CountryId });
                }
            }
            return states.AsEnumerable();
        }
        
    }

    public class StateVM_DataManager : VMDataManager
    {

        public StateVM stateVM { get; set; }
       
        public StateVM_DataManager()
        {
            stateVM = new StateVM();
            stateVM.selectedCountryId = "";
            stateVM.selectedStateId = "";
            stateVM.state = "";
            stateVM.country = "";
            stateVM.countries = new List<Country>();
            stateVM.statesOfThisCountry = new List<State>();
            stateVM.countriesSLI = new List<SelectListItem>();
            stateVM.stateSLI = new List<SelectListItem>();
        }

        public void SaveState(StateVM stateVM)
        {
            using (aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = new aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context())
            {
                _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.State.Add(new State() { Id = Guid.NewGuid().ToString(), Name = stateVM.state, CountryId = stateVM.selectedCountryId });
                _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.SaveChanges();
            }
        }
    }




    public class CountryVM_DataManager : VMDataManager
    {
        public CountryVM countryVM;

        public CountryVM_DataManager()
        {
            countryVM = new CountryVM();
            countryVM.country = new Country();
            countryVM.countries = getCountries();
            countryVM.BusinessErrors = new List<ModelStateDictionary>();
        }
        public void SaveCountry(CountryVM countryVM)
        {
            using (aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context = new aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context())
            {
                _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.Country.Add(new Country() { Id = Guid.NewGuid().ToString(), Name = countryVM.country.Name });
                _aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context.SaveChanges();                
            }
        }
        public static ModelStateDictionary ValidateCountry(ref CountryVM countryVM)
        {
            ModelStateDictionary keyValues = new ModelStateDictionary();
            
            if (countryVM.country.Name =="aa")
            {
                keyValues.AddModelError("country.Name", "invalid country name aa");
                countryVM.BusinessErrors.Add(keyValues);               
            }

            return keyValues;
        }

    }
}
