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
    public class HotelPackageService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<HotelPackage> HotelPackageRepo;
        public HotelPackageService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            HotelPackageRepo = unitOfWork.HotelPackageRepo;
        }
        public HotelPackageEditViewModel Add(HotelPackageEditViewModel HotelPackage)
        {
            HotelPackage _HotelPackage = HotelPackageRepo.Add(HotelPackage.toModel());
            unitOfWork.commit();
            return _HotelPackage.toEditViewModel();
        }
        public HotelPackageEditViewModel Update(HotelPackageEditViewModel HotelPackage)
        {
            HotelPackage _HotelPackage = HotelPackageRepo.Update(HotelPackage.toModel());
            unitOfWork.commit();
            return _HotelPackage.toEditViewModel();
        }

        public HotelPackageViewModel GetByID(int id)
        {
            HotelPackage HotelPackage = HotelPackageRepo.GetByID(id);
            return HotelPackage.toViewModel();
        }

        public IEnumerable<HotelPackageViewModel> GetAll()
        {

            return HotelPackageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<HotelPackageViewModel> GetFilter(string Name)
        {
            var Departments = HotelPackageRepo.GetFilter(a => a.Hotel.Name == Name);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(int id)
        {
            HotelPackageRepo.Remove(HotelPackageRepo.GetFilter(i => i.ID == id).First()
               );
            unitOfWork.commit();
        }

    }
}

