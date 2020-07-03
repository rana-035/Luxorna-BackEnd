using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class Role:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<AdminRole> AdminRoles { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
