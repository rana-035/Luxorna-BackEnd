using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public class AdminRole:BaseModel
    {

        public int? AdminID { get; set; }
        public int? RoleID { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Role Role { get; set; }



    }
}
