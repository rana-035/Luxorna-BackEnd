using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class Admin:AdminUserModel
    {
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public virtual Admin admin { get; set; }

     
        public int? AdminID { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<AdminRole> AdminRoles { get; set; }


    }
}
