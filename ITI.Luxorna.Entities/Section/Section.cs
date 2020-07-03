using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class Section:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
       

        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Resturant> Resturants { get; set; }
        public virtual ICollection<Temple> Temples { get; set; }
        public virtual ICollection<Museum> Museums { get; set; }



    }
}
