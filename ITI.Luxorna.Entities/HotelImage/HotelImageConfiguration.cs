using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public class HotelImageConfiguration:EntityTypeConfiguration<HotelImage>
    {
        public HotelImageConfiguration()
        {
            ToTable("HotelImage");
            Property(i=>i.Image)
                .HasMaxLength(500)
                .IsRequired();
            HasRequired(i => i.Hotel)
                .WithMany(i => i.HotelImages)
                .HasForeignKey(i=>i.HotelID);
        }
    }
}
