using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class ItemSizeExtentions
    {

        public static ItemSizeViewModel ToViewModel(this ItemSize model)
        {
            return new ItemSizeViewModel()
            {
                ID = model.ID,
                Price=model.Price,
                Size=model.Size?.Name,
                
                //SizeView = model.Size.toViewModel()


            };
        }
        public static ItemSizeEditViewModel ToEditViewModel(this ItemSize model)
        {
            return new ItemSizeEditViewModel()
            {
               ID = model.ID,
               Price=model.Price,
               //SizeView = model.Size.toEditViewModel(),
               SizeID=model.SizeID,
               ItemID=model.ItemID,
               Size=model.Size?.Name,
             
               
               
              


            };
        }
        public static ItemSize ToModel(this ItemSizeEditViewModel model)
        {
            return new ItemSize()
            {
                ID = model.ID,
                Price = model.Price,
                //Size = model.SizeView.toModel()
                SizeID=model.SizeID,
                ItemID=model.ItemID,
               
               
               

            };
        }
    }
}