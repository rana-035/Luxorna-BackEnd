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
    public class MuseumImageController : ApiController
    {
        private readonly MuseumImageService MuseumImageService;
        public MuseumImageController(MuseumImageService service)
        {
            MuseumImageService = service;
        }
        [HttpGet]
        public IEnumerable<MuseumImageViewModel> AllMuseumImages()
        {
            return MuseumImageService.GetAll();
        }
        [HttpGet]
        public MuseumImageViewModel GetMuseumImageByID(int id)
        {
            return MuseumImageService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<MuseumImageViewModel> FilterMuseumImage(int ID)
        {
            return MuseumImageService.GetFilter(ID);
        }
        [HttpPost]
        public MuseumImageEditViewModel AddMuseumImage(MuseumImageEditViewModel MuseumImageEditView)
        {
            var MuseumImage = MuseumImageService.Add(MuseumImageEditView);
            return MuseumImage;
        }
        [HttpPost]
        public MuseumImageEditViewModel EditMuseumImage(MuseumImageEditViewModel MuseumImageEditView)
        {
            var MuseumImage = MuseumImageService.Update(MuseumImageEditView);
            return MuseumImage;
        }
        [HttpDelete]
        public void RemoveMuseumImage(int id)
        {

            MuseumImageService.Remove(new MuseumImageEditViewModel() { ID = id });

        }



    }
}