using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public class HotelConfiguration:EntityTypeConfiguration<Hotel>
    {
        public HotelConfiguration()
        {
            ToTable("Hotel");
            Property(i => i.Stars)
               .IsRequired();
            Property(i => i.Price)
              .IsRequired();
            HasRequired(i => i.Section)
                .WithMany(i => i.Hotels)
                .HasForeignKey(i => i.SectionID);
            HasMany(i => i.HotelImages)
                .WithRequired(i => i.Hotel)
                .HasForeignKey(i => i.HotelID);
            HasMany(i => i.HotelPackages)
               .WithRequired(i => i.Hotel)
               .HasForeignKey(i => i.HotelID);
        }
    }
}
