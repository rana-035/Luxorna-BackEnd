using ITI.Luxorna.Entities;
using ITI.Luxorna.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Repositories
{
    public class UnitOfWork
    {
        private EntitiesContext Context;
        public GenericRepository<Admin> AdminRepo { get; set; }
        public GenericRepository<AdminRole> AdminRoleRepo { get; set; }
        public GenericRepository<Role> RoleRepo { get; set; }
        public GenericRepository<Country> CountryRepo { get; set; }
        public GenericRepository<Package>PackageRepo { get; set; }
        public GenericRepository<Hotel> HotelRepo { get; set; }
        public GenericRepository<HotelImage> HotelImageRepo { get; set; }
        public GenericRepository<HotelPackage> HotelPackageRepo { get; set; }
        public GenericRepository<Museum> MuseumRepo { get; set; }
        public GenericRepository<MuseumImage> MuseumImageRepo { get; set; }
        public GenericRepository<MuseumPacakge> MuseumPackageRepo { get; set; }
        public GenericRepository<Resturant> ResturantRepo { get; set; }
        public GenericRepository<ResturantImage> ResturantImageRepo { get; set; }
        public GenericRepository<ResturantPacakge> ResturantPackageRepo { get; set; }

        public GenericRepository<ItemSize> ItemSizeRepo { get; set; }

        public GenericRepository<Item> ItemRepo { get; set; }

        public GenericRepository<PackageItem> PackageItemRepo { get; set; }
        public GenericRepository<Section> SectionRepo { get; set; }
        public GenericRepository<Size> SizeRepo { get; set; }

        public GenericRepository<Temple> TempleRepo { get; set; }
        public GenericRepository<TempleImage> TempleImageRepo { get; set; }
        public GenericRepository<TemplePackage> TemplePackageRepo { get; set; }

        public GenericRepository<User>UserRepo { get; set; }

        public UnitOfWork(EntitiesContext _context, GenericRepository<Admin> adminRepo,
             GenericRepository<AdminRole> adminRoleRepo,
            GenericRepository<Role> roleRepo,
            GenericRepository<Country> countryRepo,
             GenericRepository<Package> packageRepo,
              GenericRepository<Hotel> hotelRepo,
               GenericRepository<HotelImage> hotelImageRepo,
               GenericRepository<HotelPackage> hotelPackageRepo,
                GenericRepository<Museum> museumRepo,
                 GenericRepository<MuseumImage> museumImageRepo,
             GenericRepository<MuseumPacakge> museumPackageRepo,
              GenericRepository<Resturant> resturantRepo,
              GenericRepository<ResturantImage> resturantImageRepo,
               GenericRepository<ResturantPacakge> resturantPackageRepo,
               GenericRepository<ItemSize> itemSizeRepo,
               GenericRepository<Item> itemRepo,
               GenericRepository<PackageItem> packageItemRepo,
                GenericRepository<Section> sectionRepo,
                 GenericRepository<Size> sizeRepo,
                  GenericRepository<Temple> templeRepo,
                  GenericRepository<TempleImage> templeImageRepo,
                  GenericRepository<TemplePackage> templePackageRepo,
                   GenericRepository<User> userRepo)
        {
            Context = _context;
            AdminRepo = adminRepo;
            AdminRepo.Context = Context;
            AdminRoleRepo = adminRoleRepo;
            AdminRoleRepo.Context = Context;
            CountryRepo = countryRepo;
            CountryRepo.Context = Context;
            PackageRepo = packageRepo;
            PackageRepo.Context = Context;
            HotelRepo = hotelRepo;
            HotelRepo.Context = Context;
            HotelImageRepo = hotelImageRepo;
            HotelImageRepo.Context = Context;
            HotelPackageRepo = hotelPackageRepo;
            HotelPackageRepo.Context = Context;
            MuseumRepo = museumRepo;
            MuseumRepo.Context = Context;
            MuseumImageRepo = museumImageRepo;
            MuseumImageRepo.Context = Context;
            MuseumPackageRepo = museumPackageRepo;
            MuseumPackageRepo.Context = Context;
            ResturantRepo = resturantRepo;
            ResturantRepo.Context = Context;
            ResturantImageRepo = resturantImageRepo;
            ResturantImageRepo.Context = Context;
            ResturantPackageRepo = resturantPackageRepo;
            ResturantPackageRepo.Context = Context;
           ItemSizeRepo = itemSizeRepo;
            ItemSizeRepo.Context = Context;
            ItemRepo = itemRepo;
            ItemRepo.Context = Context;
            PackageItemRepo = packageItemRepo;
            PackageItemRepo.Context = Context;
            SectionRepo = sectionRepo;
            SectionRepo.Context = Context;
            SizeRepo = sizeRepo;
            SizeRepo.Context = Context;
            TempleRepo = templeRepo;
            TempleRepo.Context = Context;
            TempleImageRepo = templeImageRepo;
            TempleImageRepo.Context = Context;
            TemplePackageRepo = templePackageRepo;
            TemplePackageRepo.Context = Context;
            UserRepo = userRepo;
            UserRepo.Context = Context;
        }
        public int commit()
        {
            return Context.SaveChanges();
        }


















    }
}

