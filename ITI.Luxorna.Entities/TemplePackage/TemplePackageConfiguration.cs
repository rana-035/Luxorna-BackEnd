using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class TemplePackageConfiguration:EntityTypeConfiguration<TemplePackage>
    {
        public TemplePackageConfiguration()
        {
            ToTable("TemplePackage");

            Property(i => i.DayNumber)
                .IsRequired();
            HasRequired(i => i.Package)
                .WithMany(i => i.TemplePackages)
                .HasForeignKey(i => i.PackageID);
            HasRequired(i => i.Temple)
                .WithMany(i => i.TemplePackages)
                .HasForeignKey(i => i.TempleID);
        }
    }
}
