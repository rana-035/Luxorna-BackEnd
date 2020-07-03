using ITI.Luxorna.Services;
using ITI.Luxorna.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.Luxorna.UI
{
    public class CountryController : ApiController
    {
        private readonly CountryService CountryService;
        public CountryController(CountryService service)
        {
            CountryService = service;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<CountryViewModel>> AllCountrys()
        {
            ResultViewModels<IEnumerable<CountryViewModel>> result
               = new ResultViewModels<IEnumerable<CountryViewModel>>();
            try
            {
                var country = CountryService.GetAll();
                if (country == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = country;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [HttpGet]
        public CountryViewModel GetCountryByID(int id)
        {
            return CountryService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<CountryViewModel> FilterCountry(String Name)
        {
            return CountryService.GetFilter(Name);
        }
        [HttpPost]
        public CountryEditViewModel AddCountry(CountryEditViewModel CountryEditView)
        {
            var Country = CountryService.Add(CountryEditView);
            return Country;
        }
        [HttpPost]
        public CountryEditViewModel EditCountry(CountryEditViewModel CountryEditView)
        {
            var Country = CountryService.Update(CountryEditView);
            return Country;
        }
        [HttpDelete]
        public void RemoveCountry(int id)
        {

            CountryService.Remove(new CountryEditViewModel() { ID = id });

        }



    }
}