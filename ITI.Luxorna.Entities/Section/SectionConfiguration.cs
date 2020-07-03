using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class SectionConfiguration:EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            ToTable("Section");
            Property(i => i.Name)
              .HasMaxLength(100)
              .IsRequired();
            Property(i => i.Description)
                .HasMaxLength(600)
                .IsOptional();
            Property(i => i.CreateDate)
                .IsRequired();
            Property(i => i.UpdateDate)
                .IsOptional();
            Property(i => i.CreateBy)
               .IsRequired();
            Property(i => i.UpdateBy)
              .IsOptional();
            Property(i => i.Image)
                .HasMaxLength(500)
                .IsRequired();
            HasMany(i => i.Hotels)
                .WithRequired(i => i.Section)
                .HasForeignKey(i => i.SectionID);
            HasMany(i => i.Temples)
               .WithRequired(i => i.Section)
               .HasForeignKey(i => i.SectionID);
            HasMany(i => i.Museums)
               .WithRequired(i => i.Section)
               .HasForeignKey(i => i.SectionID);
            HasMany(i => i.Resturants)
               .WithRequired(i => i.Section)
               .HasForeignKey(i => i.SectionID);

        }
    }
}
