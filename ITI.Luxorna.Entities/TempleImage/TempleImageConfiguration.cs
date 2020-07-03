using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class TempleImageConfiguration:EntityTypeConfiguration<TempleImage>
    {
        public TempleImageConfiguration()
        {
            ToTable("TempleImage");
            Property(i => i.Image)
                .HasMaxLength(500)
                .IsRequired();
            HasRequired(i => i.Temple)
                .WithMany(i => i.TempleImages)
                .HasForeignKey(i => i.TempleID);
        }
    }
}
