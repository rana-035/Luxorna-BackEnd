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
    public class ResturantPackageService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<ResturantPacakge> ResturantPackageRepo;
        private GenericRepository<PackageItem> PackageItemRepo;
        public ResturantPackageService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ResturantPackageRepo = unitOfWork.ResturantPackageRepo;
            PackageItemRepo = unitOfWork.PackageItemRepo;
        }
        public ResturantPackageEditViewModel Add(ResturantPackageEditViewModel _ResturantPackage)
        {
            if (_ResturantPackage.ID == 0)
            {
                var returned = 
                ResturantPackageRepo.Add(_ResturantPackage.toModel());
                UnitOfWork.commit();
                _ResturantPackage.ID = returned.ID;


            }
            if (_ResturantPackage.PackageItems != null
                 && _ResturantPackage.PackageItems.Count > 0)
            {
                foreach (var packageItem in _ResturantPackage.PackageItems)
                {
                    packageItem.ResturantPackageID = _ResturantPackage.ID;
                    PackageItemRepo.Add(packageItem.toModel());

                }
            }
            UnitOfWork.commit();
            
           
           
            return _ResturantPackage;
        }
        public ResturantPackageEditViewModel Update(ResturantPackageEditViewModel _ResturantPackage)
        {
            ResturantPacakge ResturantPackage = ResturantPackageRepo.Add(_ResturantPackage.toModel());
            UnitOfWork.commit();
            return ResturantPackage.toEditViewModel();
        }
        public ResturantPackageViewModel GetByID(int id)
        {
            ResturantPacakge _ResturantPackage = ResturantPackageRepo.GetByID(id);
            return _ResturantPackage.toViewModel();
        }

        public IEnumerable<ResturantPackageViewModel> GetAll()
        {

            return ResturantPackageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<ResturantPackageViewModel> GetFilter(string name)
        {
            var ResturantPackages = ResturantPackageRepo.GetFilter(a => a.Package.Name == name);
            return ResturantPackages.ToList().Select(i => i.toViewModel());
        }

        public void Remove(int id)
        {
            ResturantPackageRepo.Remove(ResturantPackageRepo.GetFilter(i => i.ID == id).First()
             );
            UnitOfWork.commit();
        }
    }
}
