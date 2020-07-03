using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class SizeConfiguration:EntityTypeConfiguration<Size>
    {
        public SizeConfiguration()
        {
            ToTable("Size");
            Property(i => i.Name)
               .HasMaxLength(500)
               .IsRequired();

            HasMany(i => i.ItemSizes)
                .WithRequired(i => i.Size)
                .HasForeignKey(I => I.SizeID);
        }
    }
}
