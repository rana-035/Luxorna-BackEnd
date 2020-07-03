using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class ResturantPacakge:BaseModel
    {
        public int ResturantID { get; set; }
        public int PackageID { get; set; }
        public int DayNumber { get; set; }

        public virtual  Resturant Resturant { get; set; }
        public virtual  Package Package { get; set; }
        public virtual ICollection<PackageItem> PackageItems { get; set; }
    }
}
