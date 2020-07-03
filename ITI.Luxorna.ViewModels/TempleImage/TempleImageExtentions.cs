using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public static class TempleImageExtentions
    {

        public static TempleImageViewModel toViewModel(this TempleImage model)
        {
            return new TempleImageViewModel()
            {
                ID = model.ID,
                Image = model.Image

            };
        }
        public static TempleImageEditViewModel toEditViewModel(this TempleImage model)
        {
            return new TempleImageEditViewModel()
            {
                ID = model.ID,
                Image = model.Image,
                TempleID=model.TempleID
                

            };
        }
        public static TempleImage toModel(this TempleImageEditViewModel model)
        {
            return new TempleImage()
            {
                ID = model.ID,
                Image = model.Image,
                TempleID=model.TempleID
                




            };
        }
    }
}