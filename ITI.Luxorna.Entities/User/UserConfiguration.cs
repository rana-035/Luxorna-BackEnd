using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            Property(i => i.Phone)
                 .HasMaxLength(20)
                 .IsRequired();
            Property(i => i.DeleteDate)
                .IsOptional();
            Property(i => i.IsDeleted)
                .IsOptional();
            HasRequired(i => i.Country)
                .WithMany(i => i.Users)
                .HasForeignKey(i => i.CountryID);
            HasMany(i => i.Packages)
                .WithRequired(i => i.User)
                .HasForeignKey(i => i.UserID);
            HasRequired(i => i.Role)
              .WithMany(i => i.Users)
              .HasForeignKey(i => i.RoleID);





        }
    }
}
