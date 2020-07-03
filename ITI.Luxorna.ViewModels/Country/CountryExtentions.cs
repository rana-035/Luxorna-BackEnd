using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public  static class CountryExtentions
    {
        public static CountryViewModel toViewModel(this Country model)
        {
            return new CountryViewModel()
            {
                ID = model.ID,
                Name = model.Name,

            };
        }
        public static CountryEditViewModel toEditViewModel(this Country model)
        {
            return new CountryEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,

            };
        }
        public static Country toModel(this CountryEditViewModel model)
        {
            return new Country()
            {
                ID = model.ID,
                Name = model.Name,



            };
        }
    }
}
