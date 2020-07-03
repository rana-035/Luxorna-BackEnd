using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class TemplePackageExtentions
    {
        public static TemplePackageViewModel toViewModel(this TemplePackage model)
        {
            return new TemplePackageViewModel()
            {
                ID = model.ID,
                DayNumber = model.DayNumber,
                TempleID = model.TempleID,
                PackageID = model.PackageID
            };
        }
        public static TemplePackageEditViewModel toEditViewModel(this TemplePackage model)
        {
            return new TemplePackageEditViewModel()
            {
                ID = model.ID,
                DayNumber = model.DayNumber,
                TempleID=model.TempleID,
                PackageID=model.PackageID

            };
        }
        public static TemplePackage toModel(this TemplePackageEditViewModel model)
        {
            return new TemplePackage()
            {
                ID = model.ID,
                DayNumber = model.DayNumber,
                TempleID = model.TempleID,
                PackageID = model.PackageID
            };
        }
    }
}