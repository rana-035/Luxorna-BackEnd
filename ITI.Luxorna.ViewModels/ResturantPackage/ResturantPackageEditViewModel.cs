using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class ResturantPackageEditViewModel
    {
        public int ID { get; set; }
        public int DayNumber { get; set; }
        public int PackageID { get; set; }
        public int RestuarantID { get; set; }
        public List<PackageItemEditViewModel> PackageItems { get; set; }
    }
}
