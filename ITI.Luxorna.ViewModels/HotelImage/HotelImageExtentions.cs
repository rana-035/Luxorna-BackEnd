using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class HotelImageExtentions
    {
        public static HotelImageViewModel toViewModel(this HotelImage model)
        {
            return new HotelImageViewModel()
            {
                ID = model.ID,
                Image = model.Image,
                
                
            };
        }
        public static HotelImageEditViewModel toEditViewModel(this HotelImage model)
        {
            return new HotelImageEditViewModel()
            {
                ID = model.ID,
                Image = model.Image,
                HotelID=model.HotelID


            };
        }
        public static HotelImage toModel(this HotelImageEditViewModel model)
        {
            return new HotelImage()
            {
                ID = model.ID,
                Image = model.Image,
                HotelID=model.HotelID




            };
        }
    }
}