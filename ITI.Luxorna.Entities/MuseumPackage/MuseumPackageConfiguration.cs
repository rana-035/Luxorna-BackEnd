using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class MuseumPackageConfiguration:EntityTypeConfiguration<MuseumPacakge>
    {
        public MuseumPackageConfiguration()
        {
            ToTable("MuseumPackage");

            Property(i => i.DayNumber)
                .IsRequired();
            HasRequired(i => i.Package)
                .WithMany(i => i.MuseumPacakges)
                .HasForeignKey(i => i.PackageID);
            HasRequired(i => i.Museum)
                .WithMany(i => i.MuseumPacakges)
                .HasForeignKey(i => i.MuseumID);
        }
    }
}
