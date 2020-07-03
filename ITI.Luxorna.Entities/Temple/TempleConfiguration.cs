using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class TempleConfiguration:EntityTypeConfiguration<Temple>
    {
        public TempleConfiguration()
        {
            ToTable("Temple");

            Property(i => i.TicketPrice)
                .IsRequired();
            HasRequired(i => i.Section)
               .WithMany(i => i.Temples)
               .HasForeignKey(i => i.SectionID);

            HasMany(i => i.TempleImages)
                .WithRequired(i => i.Temple)
                .HasForeignKey(i => i.TempleID);

            HasMany(i => i.TemplePackages)
              .WithRequired(i => i.Temple)
              .HasForeignKey(i => i.TempleID);
        }
        
    }
}
