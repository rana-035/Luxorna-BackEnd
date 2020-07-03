using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class PlaceModelConfiguration:EntityTypeConfiguration<PlaceModel>
    {
        public PlaceModelConfiguration()
        {
            Property(i => i.Name)
               .HasMaxLength(100)
               .IsRequired();
            Property(i => i.Description)
                .HasMaxLength(600)
                .IsOptional();
            Property(i => i.Address)
               .HasMaxLength(600)
               .IsRequired();
            Property(i => i.CreateDate)
                .IsRequired();
            Property(i => i.UpdateDate)
                .IsOptional();
            Property(i => i.CreateBy)
               .IsRequired();
            Property(i => i.UpdateBy)
              .IsOptional();

        }
    }
}
