using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public static class SizeExtentions
    {

        public static SizeViewModel ToViewModel(this Size model)
        {
            return new SizeViewModel()
            {
                ID = model.ID,
                Name = model.Name
                
            };
        }
        public static SizeEditViewModel ToEditViewModel(this Size model)
        {
            return new SizeEditViewModel()
            {
                ID = model.ID,
               Name = model.Name
            };
        }
        public static Size ToModel(this SizeEditViewModel model)
        {
            return new Size()
            {
                ID = model.ID,
                Name = model.Name


            };
        }
    }
}