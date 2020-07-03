using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
   public  class RoleConfiguration:EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Role");
            Property(i => i.Name)
                .HasMaxLength(500)
                .IsRequired();
            HasMany(i => i.AdminRoles)
                .WithRequired(i => i.Role)
                .HasForeignKey(i => i.RoleID);
            HasMany(i => i.AdminRoles)
                .WithRequired(i => i.Role)
                .HasForeignKey(i => i.RoleID);

            HasMany(i => i.Users)
                 .WithRequired(i => i.Role)
                 .HasForeignKey(i => i.RoleID);



        }
    }
}
