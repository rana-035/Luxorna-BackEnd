using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public class ResturantImageConfiguration:EntityTypeConfiguration<ResturantImage>
    {
        public ResturantImageConfiguration()
        {
            ToTable("ResturantImage");
            Property(i => i.Image)
                .HasMaxLength(500)
                .IsRequired();
            HasRequired(i => i.Resturant)
                .WithMany(i => i.ResturantImages)
                .HasForeignKey(i => i.ResturantID);
        }
    }
}
