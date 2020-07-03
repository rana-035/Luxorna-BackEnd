using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class ResturantPackageConfiguration:EntityTypeConfiguration<ResturantPacakge>
    {
        public ResturantPackageConfiguration()
        {
            ToTable("ResturantPackage");

            Property(i => i.DayNumber)
                .IsRequired();
            HasRequired(i => i.Package)
                .WithMany(i => i.ResturantPacakges)
                .HasForeignKey(i => i.PackageID);
            HasRequired(i => i.Resturant)
                .WithMany(i => i.ResturantPacakges)
                .HasForeignKey(i => i.ResturantID);

            HasMany(i => i.PackageItems)
                .WithRequired(i => i.ResturantPacakge)
                .HasForeignKey(i => i.ResturantPackageID);
        }
    }
}
