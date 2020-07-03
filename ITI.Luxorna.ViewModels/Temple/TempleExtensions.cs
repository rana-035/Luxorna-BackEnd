using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class TempleExtensions
    {
        public static TempleViewModel toViewModel(this Temple model)
        {
            return new TempleViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
               TicketPrice = model.TicketPrice,
                SectionName = model.Section?.Name
               
               //TempleImages = model.TempleImages
            };
        }
        public static TempleEditViewModel toEditViewModel(this Temple model)
        {
            return new TempleEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
               TicketPrice = model.TicketPrice,
                SectionName = model.Section?.Name,
                SectionID = model.SectionID,
               
          
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate,
                UpdateBy = model.UpdateBy,
                UpdateDate = model.UpdateDate
            };
        }
        public static Temple toModel(this TempleEditViewModel model)
        {
            return new Temple()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
               TicketPrice = model.TicketPrice,
                SectionID = model.SectionID,
               
              // TempleImages = model.TempleImages,
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate,
                UpdateBy = model.UpdateBy,
                UpdateDate = model.UpdateDate

            };
        }
    }
}
