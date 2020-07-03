using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class PackageEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonNumber { get; set; }
        public decimal? TotalPrice { get; set; } = 0;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public int UserID { get; set; }

        //public IEnumerable<HotelPackageEditViewModel> HotelPackages { get; set; }
        //public IEnumerable<ResturantPackageEditViewModel> ResturantPackages { get; set; }
        //public IEnumerable<TemplePackageEditViewModel> TemplePackages { get; set; }

    }
}
