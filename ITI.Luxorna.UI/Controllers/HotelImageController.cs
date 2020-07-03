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
    public class HotelImageController : ApiController
    {
        private readonly HotelImageService HotelImageService;
        public HotelImageController(HotelImageService service)
        {
            HotelImageService = service;
        }
        [HttpGet]
        public IEnumerable<HotelImageViewModel> AllHotelImages()
        {
            return HotelImageService.GetAll();
        }
        [HttpGet]
        public HotelImageViewModel GetHotelImageByID(int id)
        {
            return HotelImageService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<HotelImageViewModel> FilterHotelImage(int ID)
        {
            return HotelImageService.GetFilter(ID);
        }
        [HttpPost]
        public HotelImageEditViewModel AddHotelImage(HotelImageEditViewModel HotelImageEditView)
        {
            var HotelImage = HotelImageService.Add(HotelImageEditView);
            return HotelImage;
        }
        [HttpPost]
        public HotelImageEditViewModel EditHotelImage(HotelImageEditViewModel HotelImageEditView)
        {
            var HotelImage = HotelImageService.Update(HotelImageEditView);
            return HotelImage;
        }
        [HttpDelete]
        public void RemoveHotelImage(int id)
        {

            HotelImageService.Remove(new HotelImageEditViewModel() { ID = id });

        }



    }
}