using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class ItemEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ResturantID { get; set; }
        public List <ItemSizeEditViewModel> ItemDetail { get; set; }
    }
}
