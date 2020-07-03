using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class CountryConfiguration:EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            ToTable("Country");
            Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired();
            HasMany(i => i.Users)
                .WithRequired(i => i.Country)
                .HasForeignKey(i => i.CountryID);
        }
    }
}
