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
    public class TempleImageController : ApiController
    {
        private readonly TempleImageService TempleImageService;
        public TempleImageController(TempleImageService service)
        {
            TempleImageService = service;
        }
        [HttpGet]
        public IEnumerable<TempleImageViewModel> AllTempleImages()
        {
            return TempleImageService.GetAll();
        }
        [HttpGet]
        public TempleImageViewModel GetTempleImageByID(int id)
        {
            return TempleImageService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<TempleImageViewModel> FilterTempleImage(String Name)
        {
            return TempleImageService.GetFilter(Name);
        }
        [HttpPost]
        public TempleImageEditViewModel AddTempleImage(TempleImageEditViewModel TempleImageEditView)
        {
            var TempleImage = TempleImageService.Add(TempleImageEditView);
            return TempleImage;
        }
        [HttpPost]
        public TempleImageEditViewModel EditTempleImage(TempleImageEditViewModel TempleImageEditView)
        {
            var TempleImage = TempleImageService.Update(TempleImageEditView);
            return TempleImage;
        }
        [HttpDelete]
        public void RemoveTempleImage(int id)
        {

            TempleImageService.Remove(new TempleImageEditViewModel() { ID = id });

        }
    }
}
