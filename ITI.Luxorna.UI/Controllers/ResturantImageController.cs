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
    public class ResturantImageController : ApiController
    {
        private readonly ResturantImageService resturantImageService;
        public ResturantImageController(ResturantImageService _resturantImageService)
        {
            resturantImageService = _resturantImageService;
        }
        [HttpGet]
        public IEnumerable<ResturantImageViewModel> AllResturantImages()
        {
            return resturantImageService.GetAll();
        }
        [HttpGet]
        public ResturantImageViewModel GetResturantImageByID(int id)
        {
            return resturantImageService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<ResturantImageViewModel> FilterResturantImage(String image)
        {
            return resturantImageService.GetFilter(image);
        }
        [HttpPost]
        public ResturantImageEditViewModel AddResturantImage(ResturantImageEditViewModel ResturantImageEditView)
        {
            var ResturantImage = resturantImageService.Add(ResturantImageEditView);
            return ResturantImage;
        }
        public ResturantImageEditViewModel EditResturantImage(ResturantImageEditViewModel ResturantImageEditView)
        {
            var ResturantImage = resturantImageService.Update(ResturantImageEditView);
            return ResturantImage;
        }
        [HttpDelete]
        public void RemoveResturantImage(int id)
        {

            resturantImageService.Remove(new ResturantImageEditViewModel() { ID = id });

        }
       
    }
}
