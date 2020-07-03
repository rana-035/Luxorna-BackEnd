using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public static class PackageExtentions
    {
        public static PackageViewModel toViewModel(this Package model)
        {
            return new PackageViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                EndDate=model.EndDate,
                PersonNumber=model.PersonNumber,
                StartDate=model.StartDate,
                TotalPrice=model.TotalPrice,
                UserID=model.UserID

            };
        }
        public static PackageEditViewModel toEditViewModel(this Package model)
        {
            return new PackageEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                PersonNumber = model.PersonNumber,
                TotalPrice = model.TotalPrice,
                UpdateDate = model.UpdateDate,
                CreateDate=model.CreateDate,
                UserID=model.UserID
                

            };
        }
        public static Package toModel(this PackageEditViewModel model)
        {
            return new Package()
            {
                ID = model.ID,
                Name = model.Name,
                CreateDate=model.CreateDate,
                TotalPrice=model.TotalPrice,
                StartDate=model.StartDate,
                UpdateDate=model.UpdateDate,
                EndDate=model.EndDate,
                PersonNumber=model.PersonNumber,
                UserID=model.UserID
                
            };
        }
    }
}