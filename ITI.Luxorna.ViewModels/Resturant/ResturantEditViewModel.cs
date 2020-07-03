using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class ResturantEditViewModel
    {
        public int ID { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public IEnumerable<ResturantImageEditViewModel> ResturantImages { get; set; }
        public IEnumerable<ItemEditViewModel> Items { get; set; }
        
    }
}
