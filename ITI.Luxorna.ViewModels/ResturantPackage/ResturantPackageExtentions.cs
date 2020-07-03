using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
  public static  class  ResturantPackageExtentions
    {
        public static ResturantPackageViewModel toViewModel(this ResturantPacakge model)
        {
            return new ResturantPackageViewModel()
            {
                ID = model.ID,
                DayNumber = model.DayNumber
            };
        }
        public static ResturantPackageEditViewModel toEditViewModel(this ResturantPacakge model)
        {
            return new ResturantPackageEditViewModel()
            {
                ID = model.ID,
                DayNumber = model.DayNumber,
                PackageID=model.PackageID,
                RestuarantID=model.ResturantID,
                

            };
        }
        public static ResturantPacakge toModel(this ResturantPackageEditViewModel model)
        {
            return new ResturantPacakge()
            {
                ID = model.ID,
                PackageID = model.PackageID,
                ResturantID = model.RestuarantID,
                DayNumber = model.DayNumber,
            };
        }
    }
}