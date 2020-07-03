using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class MuseumPacakge:BaseModel
    {
        public int MuseumID { get; set; }
        public int PackageID { get; set; }
        public int DayNumber { get; set; }

        public virtual Museum Museum { get; set; }
        public virtual Package Package { get; set; }
    }
}
