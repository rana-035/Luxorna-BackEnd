using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public  class ItemSizeEditViewModel
    {
        public int ID { get; set; }

        public decimal Price { get; set; }
        public int SizeID { get; set; }
        public int ItemID { get; set; }
        public string Size { get; set; }


    }
}
