using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public class MuseumImage:BaseModel
    {
        public string Image { get; set; }
        public int MuseumID { get; set; }
        public virtual Museum Museum { get; set; }
    }
}
