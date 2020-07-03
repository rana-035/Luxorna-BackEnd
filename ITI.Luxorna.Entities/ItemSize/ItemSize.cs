using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class ItemSize : BaseModel
    {
        public int SizeID{get;set;}
        public int ItemID { get; set; }
        public decimal Price { get; set;}
        public virtual Size Size { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<PackageItem> PackageItems { get; set; }

    }
}
