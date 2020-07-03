using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Entities
{
    public class AdminRoleConfiguration:EntityTypeConfiguration<AdminRole>
    {
        public  AdminRoleConfiguration()
        {
            ToTable("AdminRole");
            HasRequired(i => i.Admin)
                .WithMany(i => i.AdminRoles)
                .HasForeignKey(i => i.AdminID);
            HasRequired(i => i.Role)
               .WithMany(i => i.AdminRoles)
               .HasForeignKey(i => i.RoleID);
        }
    }
}
