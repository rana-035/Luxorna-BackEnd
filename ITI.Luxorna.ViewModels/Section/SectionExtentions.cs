using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class SectionExtentions
    {
        public static SectionViewModel toViewModel(this Section model)
        {
            return new SectionViewModel()
            {
                ID=model.ID,
                Name=model.Name,
                Description=model.Description,
                Image=model.Image
            };
        }
        public static SectionEditViewModel toEditViewModel(this Section model)
        {
            return new SectionEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                CreateBy=model.CreateBy,
                UpdateBy=model.UpdateBy,
                UpdateDate=model.UpdateDate,
                CreateDate=model.CreateDate
            };
        }
        public static Section toModel(this SectionEditViewModel model)
        {
            return new Section()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                CreateBy = model.CreateBy,
                UpdateBy = model.UpdateBy,
                UpdateDate = model.UpdateDate,
                CreateDate = model.CreateDate,
                
               
            };
        }
    }
}
