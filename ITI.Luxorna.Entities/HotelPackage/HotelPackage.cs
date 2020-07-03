using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class HotelPackage : BaseModel
    {
        public int HotelID { get; set; }
        public int PackageID { get; set; }
        public int DayNumber { get; set; }

        public virtual Hotel Hotel {get;set;}
        public virtual Package Package { get; set; }


    }
}
