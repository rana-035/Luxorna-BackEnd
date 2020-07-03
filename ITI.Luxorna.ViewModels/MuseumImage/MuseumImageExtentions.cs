using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public static class MuseumImageExtentions
    {

        public static MuseumImageViewModel toViewModel(this MuseumImage model)
        {
            return new MuseumImageViewModel()
            {
                ID = model.ID,
                Image = model.Image

            };
        }
        public static MuseumImageEditViewModel toEditViewModel(this MuseumImage model)
        {
            return new MuseumImageEditViewModel()
            {
                ID = model.ID,
                Image = model.Image


            };
        }
        public static MuseumImage toModel(this MuseumImageEditViewModel model)
        {
            return new MuseumImage()
            {
                ID = model.ID,
                Image = model.Image




            };
        }
    }
}