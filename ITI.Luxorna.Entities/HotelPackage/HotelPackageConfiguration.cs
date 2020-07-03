using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class HotelPackageConfiguration:EntityTypeConfiguration<HotelPackage>
    {
        public HotelPackageConfiguration()
        {
            ToTable("HotelPackage");

            Property(i => i.DayNumber)
                .IsRequired();
            HasRequired(i => i.Package)
                .WithMany(i => i.HotelPackages)
                .HasForeignKey(i => i.PackageID);
            HasRequired(i => i.Hotel)
                .WithMany(i => i.HotelPackages)
                .HasForeignKey(i => i.HotelID);
        }
    }
}
