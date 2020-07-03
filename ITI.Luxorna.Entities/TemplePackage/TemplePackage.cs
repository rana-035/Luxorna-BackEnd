using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class TemplePackage:BaseModel
    {
        public int TempleID { get; set; }
        public int PackageID { get; set; }
        public int DayNumber { get; set; }

        public virtual Temple Temple { get; set; }
        public virtual Package Package { get; set; }
    }
}
