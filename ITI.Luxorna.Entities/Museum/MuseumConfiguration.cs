using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class MuseumConfiguration:EntityTypeConfiguration<Museum>
    {
        public MuseumConfiguration()
        {
            ToTable("Museum");
            Property(i => i.TicketPrice)
               .IsRequired();
            HasRequired(i => i.Section)
               .WithMany(i => i.Museums)
               .HasForeignKey(i => i.SectionID);
            HasMany(i => i.MuseumImages)
               .WithRequired(i => i.Museum)
               .HasForeignKey(i => i.MuseumID);

            HasMany(i => i.MuseumPacakges)
              .WithRequired(i => i.Museum)
              .HasForeignKey(i => i.MuseumID);
        }
       
    }
}
