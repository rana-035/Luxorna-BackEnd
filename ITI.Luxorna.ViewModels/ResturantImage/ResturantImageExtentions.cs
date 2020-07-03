using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class ResturantImageExtentions
    {

        public static ResturantImageViewModel toViewModel(this ResturantImage model)
        {
            return new ResturantImageViewModel()
            {
                ID = model.ID,
                Image = model.Image,
                //ResturantID=model.ResturantID

            };
        }
        public static ResturantImageEditViewModel ToEditViewModel(this ResturantImage model)
        {
            return new ResturantImageEditViewModel()
            {
                ID = model.ID,
                Image = model.Image,
                 ResturantID = model.ResturantID

            };
        }
        public static ResturantImage ToModel(this ResturantImageEditViewModel model)
        {
            return new ResturantImage()
            {
                ID = model.ID,
                Image = model.Image,
                ResturantID=model.ResturantID
            };
        }
    }
}