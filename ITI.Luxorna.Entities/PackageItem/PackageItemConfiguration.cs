using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class PackageItemConfiguration:EntityTypeConfiguration<PackageItem>
    {
        public PackageItemConfiguration()
        {
            ToTable("PackageItem");
            //HasRequired(i => i.Item)
            //    .WithMany(i => i.ItemPackage)
            //    .HasForeignKey(i => i.ResturantMenuItemID);
            HasRequired(i => i.ItemSize)
                .WithMany(i => i.PackageItems)
                .HasForeignKey(i => i.ItemSizeID);
            HasRequired(i => i.ResturantPacakge)
                .WithMany(i => i.PackageItems)
                .HasForeignKey(i => i.ResturantPackageID);
            Property(i => i.Quantity)
                .IsOptional();
        }
    }
}
