using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class Hotel:PlaceModel
    {
        public int Stars { get; set; }
        public decimal Price { get; set; }

        public int SectionID { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<HotelImage> HotelImages { get; set; }
        public virtual ICollection<HotelPackage> HotelPackages { get; set; }



    }
}
