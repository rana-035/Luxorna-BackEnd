using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class ItemSizeConfiguration:EntityTypeConfiguration<ItemSize>
    {
        public ItemSizeConfiguration()
        {
            ToTable("ItemSize");
            Property(i => i.Price)
                .IsRequired();
            HasRequired(i => i.Item)
                .WithMany(i => i.ItemSizes)
                .HasForeignKey(i => i.ItemID);
            HasRequired(i => i.Size)
               .WithMany(i => i.ItemSizes)
               .HasForeignKey(i => i.SizeID);
            HasMany(i => i.PackageItems)
                .WithRequired(o => o.ItemSize)
                .HasForeignKey(o => o.ItemSizeID);
        }
    }
}
