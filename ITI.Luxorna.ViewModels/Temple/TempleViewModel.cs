using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public class TempleViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal TicketPrice { get; set; }
        public string SectionName { get; set; }
        public IEnumerable<TempleImageViewModel> TempleImages { get; set; }
    }
}
