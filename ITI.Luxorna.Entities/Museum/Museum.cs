using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class Museum : PlaceModel
    {
        public int SectionID { get; set; }
        public decimal TicketPrice { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<MuseumImage> MuseumImages { get; set; }
        public virtual ICollection<MuseumPacakge> MuseumPacakges { get; set; }



    }
}
