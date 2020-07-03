using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class Package:BaseModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<HotelPackage> HotelPackages { get; set; }
        public virtual ICollection<TemplePackage> TemplePackages { get; set; }
        public virtual ICollection<MuseumPacakge> MuseumPacakges { get; set; }
        public virtual ICollection<ResturantPacakge> ResturantPacakges { get; set; }









    }
}
