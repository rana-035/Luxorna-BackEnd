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
    public class MuseumController : ApiController
    {
        private readonly MuseumService MuseumService;
        public MuseumController(MuseumService service)
        {
            MuseumService = service;
        }
        [HttpGet]
        public IEnumerable<MuseumViewModel> AllMuseums()
        {
            return MuseumService.GetAll();
        }
        [HttpGet]
        public MuseumViewModel GetMuseumByID(int id)
        {
            return MuseumService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<MuseumViewModel> FilterMuseum(String Name)
        {
            return MuseumService.GetFilter(Name);
        }
        [HttpPost]
        public MuseumEditViewModel AddMuseum(MuseumEditViewModel MuseumEditView)
        {
            var Museum = MuseumService.Add(MuseumEditView);
            return Museum;
        }
        [HttpPost]
        public MuseumEditViewModel EditMuseum(MuseumEditViewModel MuseumEditView)
        {
            var Museum = MuseumService.Update(MuseumEditView);
            return Museum;
        }
        [HttpDelete]
        public void RemoveMuseum(int id)
        {

            MuseumService.Remove(new MuseumEditViewModel() { ID = id });

        }



    }
}