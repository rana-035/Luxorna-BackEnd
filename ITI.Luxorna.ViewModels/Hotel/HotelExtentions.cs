using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class HotelExtentions
    {
        public static HotelViewModel toViewModel(this Hotel model)
        {
            return new HotelViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
                Price = model.Price,
                SectionName = model.Section?.Name,
                Stars = model.Stars,
                //HotelImages = model.HotelImages
            };
        }
        public static HotelEditViewModel toEditViewModel(this Hotel model)
        {
            return new HotelEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
                Price = model.Price,
                //SectionName = model.Section.Name,
                SectionID = model.SectionID,
                Stars = model.Stars,
               
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate,
                UpdateBy = model.UpdateBy,
                UpdateDate = model.UpdateDate,
               
            };
        }
        public static Hotel toModel(this HotelEditViewModel model)
        {
            return new Hotel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
                Price = model.Price,               
                SectionID = model.SectionID,
                Stars = model.Stars,
               // HotelImages = model.HotelImages,
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate,
                UpdateBy = model.UpdateBy,
                UpdateDate = model.UpdateDate

            };
        }
    }
}
