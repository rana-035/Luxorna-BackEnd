using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class PackageItem:BaseModel
    {
       public int ResturantPackageID { get; set; }
        public virtual ResturantPacakge ResturantPacakge { get; set; }
        public virtual ItemSize ItemSize { get; set; }
        public int ItemSizeID { get; set; }
        public int Quantity { get; set; }
    }
}
