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
    public class MuseumPackageController : ApiController
    {
        private readonly MuseumPackageService museumPackageService;
        public MuseumPackageController(MuseumPackageService _museumPackageService)
        {
            museumPackageService = _museumPackageService;
        }
        [HttpGet]
        public IEnumerable<MuseumPackageViewModel> AllMuseumPackages()
        {
            return museumPackageService.GetAll();
        }

        [HttpGet]
        public MuseumPackageViewModel GetMuseumPackageByID(int id)
        {
            return museumPackageService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<MuseumPackageViewModel> FilterMuseumPackage(String Name)
        {
            return museumPackageService.GetFilter(Name);
        }
        [HttpPost]
        public MuseumPackageEditViewModel AddMuseumPackage(MuseumPackageEditViewModel museumPackageEditView)
        {
            var museumPackage = museumPackageService.Add(museumPackageEditView);
            return museumPackage;
        }
        [HttpPost]
        public MuseumPackageEditViewModel EditMuseumPackage(MuseumPackageEditViewModel museumPackageEditView)
        {
            var museumPackage = museumPackageService.Update(museumPackageEditView);
            return museumPackage;

        }
        [HttpDelete]
        public void RemoveMuseumPackage(int id)
        {

            museumPackageService.Remove(new MuseumPackageEditViewModel() { ID = id });

        }
    }
}