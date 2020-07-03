using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class HotelPackagePackageExtentions
    {
        public static HotelPackageViewModel toViewModel(this HotelPackage model)
        {
            return new HotelPackageViewModel()
            {
                ID = model.ID,
                DayNumber=model.DayNumber,
                HotelID = model.HotelID,
                PackageID = model.PackageID
            };
        }
        public static HotelPackageEditViewModel toEditViewModel(this HotelPackage model)
        {
            return new HotelPackageEditViewModel()
            {
                ID = model.ID,
                DayNumber = model.DayNumber,
                HotelID=model.HotelID,
                PackageID=model.PackageID

            };
        }
        public static HotelPackage toModel(this HotelPackageEditViewModel model)
        {
            return new HotelPackage()
            {
                ID = model.ID,
                DayNumber = model.DayNumber,
                HotelID = model.HotelID,
                PackageID = model.PackageID
            };
        }
    }
}
