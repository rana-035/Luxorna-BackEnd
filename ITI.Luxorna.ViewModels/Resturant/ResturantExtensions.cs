using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class ResturantExtensions
    {
        public static ResturantViewModel toViewModel(this Resturant model)
        {
            return new ResturantViewModel()
            {
                ID=model.ID,
                Name=model.Name,
                Address=model.Address,
                //CreateBy=model.CreateBy,
                CreateDate=model.CreateDate,
                Description=model.Description,

                SectionName=model.Section.Name,
                //UpdateBy=model.UpdateBy,
                UpdateDate=model.UpdateDate
                
            };
        }
        public static ResturantEditViewModel ToEditViewModel(this Resturant model)
        {
            return new ResturantEditViewModel()
            {
                ID=model.ID,
                UpdateDate=model.UpdateDate,
                Address=model.Address,
                UpdateBy=model.UpdateBy,
                Name=model.Name,
                CreateBy=model.CreateBy,
                CreateDate=model.CreateDate,
                Description=model.Description,
                ResturantImages=model.ResturantImages?.Select(i=>i.ToEditViewModel())?.ToList(),
                Items = model.Items?.Select(i => i.ToEditViewModel())?.ToList(),
                //ResturantMenuItems = model.ResturantMenuItems.
                SectionID = model.SectionID,
                SectionName=model.Section?.Name
                
            };
        }
        public static Resturant ToModel(this ResturantEditViewModel model)
        {
            return new Resturant()
            {
                ID=model.ID,
                Name=model.Name,
                SectionID=model.SectionID,
                UpdateBy=model.UpdateBy,
                UpdateDate=model.UpdateDate,
                CreateBy = model.CreateBy,
                CreateDate = model.CreateDate,
                Address =model.Address,
                Description=model.Description
            };
        }
    }
}
