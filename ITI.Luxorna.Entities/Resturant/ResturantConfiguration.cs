using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class ResturantConfiguration:EntityTypeConfiguration<Resturant>
    {
        public ResturantConfiguration()
        {
            ToTable("Resturant");
            HasRequired(i => i.Section)
               .WithMany(i => i.Resturants)
               .HasForeignKey(i => i.SectionID);
            HasMany(i => i.ResturantImages)
                .WithRequired(i => i.Resturant)
                .HasForeignKey(i => i.ResturantID);

            HasMany(i => i.Items)
                .WithRequired(i => i.Resturant)
                .HasForeignKey(i => i.RestrantID);

            HasMany(i => i.ResturantPacakges)
               .WithRequired(i => i.Resturant)
               .HasForeignKey(i => i.ResturantID);

        }
    }
}
