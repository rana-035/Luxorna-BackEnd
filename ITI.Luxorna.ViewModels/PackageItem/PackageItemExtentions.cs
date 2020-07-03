using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class PackageItemExtentions
    {
        public static PackageItemViewModel toViewModel(this PackageItem model)
        {
            return new PackageItemViewModel()
            {
                ID = model.ID,
              ItemSizeID=model.ItemSizeID,
              ResturantPackageID=model.ResturantPackageID
            };
        }
        public static PackageItemEditViewModel toEditViewModel(this PackageItem model)
        {
            return new PackageItemEditViewModel()
            {
                ID = model.ID,
                ItemSizeID = model.ItemSizeID,
                ResturantPackageID = model.ResturantPackageID,
                Quantity = model.Quantity


            };
        }
        public static PackageItem toModel(this PackageItemEditViewModel model)
        {
            return new PackageItem()
            {
                ID = model.ID,
                ItemSizeID = model.ItemSizeID,
                ResturantPackageID = model.ResturantPackageID,
                Quantity=model.Quantity
            };
        }
    }
}
