using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public static class MuseumPackageExtentions
    {
        public static MuseumPackageViewModel toViewModel(this MuseumPacakge model)
        {
            return new MuseumPackageViewModel()
            {
                ID = model.ID,
                DayNumber = model.DayNumber
            };
        }
        public static MuseumPackageEditViewModel toEditViewModel(this MuseumPacakge model)
        {
            return new MuseumPackageEditViewModel()
            {
                ID = model.ID,
                DayNumber = model.DayNumber

            };
        }
        public static MuseumPacakge toModel(this MuseumPackageEditViewModel model)
        {
            return new MuseumPacakge()
            {
                ID = model.ID,
                DayNumber = model.DayNumber
            };
        }
    }
}