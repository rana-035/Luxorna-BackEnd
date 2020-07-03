using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class Resturant : PlaceModel
    {
        public int SectionID { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<ResturantImage> ResturantImages { get; set; }
        public virtual ICollection<Item> Items { get; set;}
        public virtual ICollection<ResturantPacakge> ResturantPacakges { get; set; }



    }
}
