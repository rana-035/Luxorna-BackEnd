using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class MuseumExtensions
    {
        public static MuseumViewModel toViewModel(this Museum model)
        {
            return new MuseumViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
                TicketPrice = model.TicketPrice,
                SectionName = model.Section.Name,

                MuseumImages = model.MuseumImages
            };
        }
        public static MuseumEditViewModel toEditViewModel(this Museum model)
        {
            return new MuseumEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
                TicketPrice = model.TicketPrice,
                SectionName = model.Section.Name,
                SectionID = model.Section.ID,

                MuseumImages = model.MuseumImages,
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate,
                UpdateBy = model.UpdateBy,
                UpdateDate = model.UpdateDate
            };
        }
        public static Museum toModel(this MuseumEditViewModel model)
        {
            return new Museum()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Address = model.Address,
                TicketPrice = model.TicketPrice,
                SectionID = model.SectionID,

                MuseumImages = model.MuseumImages,
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate,
                UpdateBy = model.UpdateBy,
                UpdateDate = model.UpdateDate

            };
        }
    }
}
