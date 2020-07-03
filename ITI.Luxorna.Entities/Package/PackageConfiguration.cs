using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class PackageConfiguration:EntityTypeConfiguration<Package>
    {
        public PackageConfiguration()
        {
            ToTable("Package");
            Property(i => i.Name)
                .HasMaxLength(500)
                .IsOptional();

            Property(i => i.StartDate)
               .IsRequired();
            Property(i => i.EndDate)
               .IsRequired();
            Property(i => i.PersonNumber)
               .IsRequired();
            Property(i => i.TotalPrice)
               .IsOptional();
            Property(i => i.CreateDate)
               .IsRequired();
            Property(i => i.UpdateDate)
               .IsOptional();

            HasRequired(i => i.User)
                .WithMany(i => i.Packages)
                .HasForeignKey(i => i.UserID);

            HasMany(i => i.HotelPackages)
               .WithRequired(i => i.Package)
               .HasForeignKey(i => i.PackageID);

            HasMany(i => i.TemplePackages)
              .WithRequired(i => i.Package)
              .HasForeignKey(i => i.PackageID);

            HasMany(i => i.MuseumPacakges)
              .WithRequired(i => i.Package)
              .HasForeignKey(i => i.PackageID);

            HasMany(i => i.ResturantPacakges)
             .WithRequired(i => i.Package)
             .HasForeignKey(i => i.PackageID);








        }
    }
}
