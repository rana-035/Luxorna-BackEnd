using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
   public class TempleEditViewModel
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
        public IEnumerable<TempleImageEditViewModel> TempleImages { get; set; }

        public int? CreateBy { get; set; } 
        public int? UpdateBy { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }= DateTime.Now;
        public DateTime UpdateDate { get; set; }= DateTime.Now;
    }
}
