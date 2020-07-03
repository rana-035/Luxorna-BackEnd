using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class Country:BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
