using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Repositories.Context
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("name=luxornaProject")
        {

        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminRole> AdminRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Temple> Temples { get; set; }
        public virtual DbSet<Museum> Museums { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Resturant> Resturants { get; set; }
        public virtual DbSet<TempleImage> TempleImages { get; set; }
        public virtual DbSet<MuseumImage> MuseumImages { get; set; }
        public virtual DbSet<HotelImage> HotelImages { get; set; }
        public virtual DbSet<ResturantImage> ResturantImages { get; set; }

        public virtual DbSet<ItemSize> ItemSizes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Size> Size { get; set; }

        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<HotelPackage> HotelPackages { get; set; }
        public virtual DbSet<ResturantPacakge> ResturantPacakges { get; set; }
        public virtual DbSet<PackageItem>PackageItems { get; set; }
        public virtual DbSet<TemplePackage> TemplePackages { get; set; }
        public virtual DbSet<MuseumPacakge> MuseumPacakges { get; set; }



























        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new AdminRoleConfiguration());


            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new SectionConfiguration());
            modelBuilder.Configurations.Add(new HotelConfiguration());
            modelBuilder.Configurations.Add(new TempleConfiguration());
            
            modelBuilder.Configurations.Add(new ResturantConfiguration());
            modelBuilder.Configurations.Add(new MuseumConfiguration());

            modelBuilder.Configurations.Add(new TempleImageConfiguration());
            modelBuilder.Configurations.Add(new ResturantImageConfiguration());
            modelBuilder.Configurations.Add(new HotelImageConfiguration());
            modelBuilder.Configurations.Add(new MuseumImageConfiguration());

            modelBuilder.Configurations.Add(new ItemSizeConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new SizeConfiguration());


            modelBuilder.Configurations.Add(new PackageConfiguration());

           
            modelBuilder.Configurations.Add(new HotelPackageConfiguration());
            modelBuilder.Configurations.Add(new TemplePackageConfiguration());
            modelBuilder.Configurations.Add(new MuseumPackageConfiguration());
            modelBuilder.Configurations.Add(new ResturantPackageConfiguration());
            modelBuilder.Configurations.Add(new PackageItemConfiguration());




            modelBuilder
                .Conventions
                .Remove<OneToManyCascadeDeleteConvention>();





















        }
    }
}
