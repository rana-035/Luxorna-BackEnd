using ITI.Luxorna.Entities;
using ITI.Luxorna.Repositories;
using ITI.Luxorna.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Services
{
    public class PackageService
    {
        //
        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<Package> packageRepo;
        private GenericRepository<HotelPackage> hotelPackageRepo;
        private GenericRepository<ResturantPacakge> resturantPackageRepo;
        private GenericRepository<TemplePackage> templePackageRepo;
      





        public PackageService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            packageRepo = unitOfWork.PackageRepo;
            hotelPackageRepo = unitOfWork.HotelPackageRepo;
            resturantPackageRepo = unitOfWork.ResturantPackageRepo;
            templePackageRepo = unitOfWork.TemplePackageRepo;



        }
        public PackageEditViewModel Add(PackageEditViewModel package)
        {
        
            Package _package = packageRepo.Add(package.toModel());
            UnitOfWork.commit();
            return _package.toEditViewModel();
            //UnitOfWork.commit();
            //if (package.HotelPackages != null && package.HotelPackages.Count() > 0)
            //    foreach (var hotel in package.HotelPackages)
            //    {
            //        hotel.PackageID = _package.ID;
            //        hotelPackageRepo.Add(hotel.toModel());
            //    }
            //if (package.TemplePackages != null && package.TemplePackages.Count() > 0)
            //    foreach (var temple in package.TemplePackages)
            //    {
            //        temple.PackageID = _package.ID;
            //        templePackageRepo.Add(temple.toModel());
            //    }

            //if (package.ResturantPackages != null && package.ResturantPackages.Count() > 0)
            //{
            //    foreach (var resturant in package.ResturantPackages)
            //    {
            //        resturant.PackageID = package.ID;
            //        ResturantPacakge Inserted = resturantPackageRepo.Add(resturant.toModel());
            //        UnitOfWork.commit();
            //        if (resturant.ItemDetail != null && item.ItemDetail.Count() > 0)
            //        {
            //            foreach (var inner in item.ItemDetail)
            //            {
            //                inner.ItemID = Inserted.ID;
            //                ItemSizeRepo.Add(inner.ToModel());
            //            }
            //        }
            //    }
            //}

        }
        public PackageEditViewModel Update(PackageEditViewModel package)
        {
            Package _package = packageRepo.Update(package.toModel());
            UnitOfWork.commit();
            return _package.toEditViewModel();
        }
        public PackageViewModel GetByID(int id)
        {
            Package _package = packageRepo.GetByID(id);
            return _package.toViewModel();
        }

        public IEnumerable<PackageViewModel> GetAll()
        {

            return packageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<PackageViewModel> GetFilter(int userID)
        {
            var packages = packageRepo.GetFilter(a => a.UserID == userID);
            return packages.ToList().Select(i => i.toViewModel());
        }
        public PagingViewModel Get(int id = 0, string name = "", int pageIndex = 1, int pageSize = 3)
        {
            var query = packageRepo.GetAll();
            if (id > 0)
                query = query.Where(i => i.UserID == id);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name.Contains(name));

            int records = query.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            query = query.OrderBy(i => i.ID).Skip(excludedRows).Take(pageSize).ToList();
            var data = query.Select(i => i.toViewModel()).ToList();
            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = data, Records = records, Pages = pages };
        }
        public void Remove(int id)
        {

            packageRepo.Remove(packageRepo.GetFilter(i => i.ID == id).First()
                );
            UnitOfWork.commit();
        }
    }
}
