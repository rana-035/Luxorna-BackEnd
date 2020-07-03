using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class AdminUserModelConfiguration:EntityTypeConfiguration<AdminUserModel>
    {
        public AdminUserModelConfiguration()
        {
            Property(i => i.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            Property(i => i.LastName)
                .HasMaxLength(100)
                .IsRequired();
            Property(i => i.Email)
                .HasMaxLength(500)
                .IsRequired();
            Property(i => i.UserName)
                .HasMaxLength(100)
                .IsRequired();
            Property(i => i.Password)
                .HasMaxLength(100)
                .IsRequired();
            Property(i => i.CreateDate)
                 .IsOptional();
            Property(i => i.UpdateDate)
                .IsOptional();
            Property(i => i.Image)
               .HasMaxLength(500)
               .IsRequired();


        }
    }
}
