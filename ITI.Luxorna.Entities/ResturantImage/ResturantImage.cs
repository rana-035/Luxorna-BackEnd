using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class ResturantImage:BaseModel
    {
        public string Image { get; set; }
        public int ResturantID { get; set; }
        public virtual Resturant Resturant { get; set; }
    }
}
