using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public class MuseumEditViewModel
    {
        [Required]
        public int ID { get; set; }
        [Required]

        public string Name { get; set; }


        public string Description { get; set; }
        [Required]

        public string Address { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }

        public string SectionName { get; set; }
        public int SectionID { get; set; }
        [Required]
        public ICollection<MuseumImage> MuseumImages { get; set; }
       
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
      
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
