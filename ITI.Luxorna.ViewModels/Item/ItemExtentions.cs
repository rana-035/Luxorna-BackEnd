using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public static  class ItemExtentions
    {
        public static ItemViewModel ToViewModel(this Item model)
        {
            return new ItemViewModel()
            {
                ID = model.ID,
                Image = model.Image,
                Name = model.Name,
                ItemDetail = model.ItemSizes?.Select(i=>i.ToViewModel()).ToList()
                
                
            };
        }
        public static ItemEditViewModel ToEditViewModel(this Item model)
        {
            return new ItemEditViewModel()
            {
                ID = model.ID,
                Image = model.Image,
                Name = model.Name,
                ResturantID=model.RestrantID,
                ItemDetail=model.ItemSizes?.Select(i=>i.ToEditViewModel())?.ToList()
                //ItemDetail = model.ResturantItemSizes.Select(i => new ResturantItemSizeEditViewModel { ID = i.ID, Price = i.Price, SizeView = i.Size.toEditViewModel() }).ToList()

            };
        }
        public static Item ToModel(this ItemEditViewModel model)
        {
            return new Item()
            {
                ID = model.ID,
                Image = model.Image,
                Name = model.Name,
                RestrantID=model.ResturantID
            };
        }
    }
}