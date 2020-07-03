using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class PackageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonNumber { get; set; }
        public decimal? TotalPrice { get; set; } = 0;
        public int UserID { get; set; }

        //public List<ResturantPackageViewModel> ResturantPackages { get; set; }
    }
}
