using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class ItemConfiguration:EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            ToTable("Item");
            Property(i => i.Name)
                .HasMaxLength(500)
                .IsRequired();
            Property(i => i.Image)
               .HasMaxLength(500)
               .IsRequired();

            HasRequired(i => i.Resturant)
                .WithMany(i => i.Items)
                .HasForeignKey(i => i.RestrantID);

            HasMany(i => i.ItemSizes)
               .WithRequired(i => i.Item)
               .HasForeignKey(I => I.ItemID);

            //HasMany(i => i.ResturantPackageMenuItems)
            //   .WithRequired(i => i.ResturantMenuItem)
            //   .HasForeignKey(i => i.ResturantMenuItemID);

        }
    }
}
