using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class Item:BaseModel
    {
        public string Name { get; set; }
      

        public string Image { get; set; }
        public int RestrantID { get; set; }
        public virtual Resturant Resturant { get; set; }
        public virtual ICollection<ItemSize> ItemSizes { get; set; }
        //public virtual ICollection<ItemPackage> ItemPackages { get; set; }

    }
}
