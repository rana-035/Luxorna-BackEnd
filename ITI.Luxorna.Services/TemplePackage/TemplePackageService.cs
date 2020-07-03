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
    public class TemplePackageService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<TemplePackage> TemplePackageRepo;
        public TemplePackageService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TemplePackageRepo = unitOfWork.TemplePackageRepo;
        }
        public TemplePackageEditViewModel Add(TemplePackageEditViewModel TemplePackage)
        {
            TemplePackage _TemplePackage = TemplePackageRepo.Add(TemplePackage.toModel());
            unitOfWork.commit();
            return _TemplePackage.toEditViewModel();
        }
        public TemplePackageEditViewModel Update(TemplePackageEditViewModel TemplePackage)
        {
            TemplePackage _TemplePackage = TemplePackageRepo.Update(TemplePackage.toModel());
            unitOfWork.commit();
            return _TemplePackage.toEditViewModel();
        }
        public TemplePackageViewModel GetByID(int id)
        {
            TemplePackage TemplePackage = TemplePackageRepo.GetByID(id);
            return TemplePackage.toViewModel();
        }

        public IEnumerable<TemplePackageViewModel> GetAll()
        {

            return TemplePackageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<TemplePackageViewModel> GetFilter(string name)
        {
            var Departments = TemplePackageRepo.GetFilter(a => a.Temple.Name == name);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(int id)
        {
            TemplePackageRepo.Remove(TemplePackageRepo.GetFilter(i => i.ID == id).First()
             );
            unitOfWork.commit();
        }
    }
}
