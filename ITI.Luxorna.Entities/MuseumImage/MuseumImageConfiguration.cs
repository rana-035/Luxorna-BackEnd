using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class MuseumImageConfiguration:EntityTypeConfiguration<MuseumImage>
    {
        public MuseumImageConfiguration()
        {
            ToTable("MuseumImage");
            Property(i => i.Image)
                .HasMaxLength(500)
                .IsRequired();
            HasRequired(i => i.Museum)
                .WithMany(i => i.MuseumImages)
                .HasForeignKey(i => i.MuseumID);
        }
    }
}
