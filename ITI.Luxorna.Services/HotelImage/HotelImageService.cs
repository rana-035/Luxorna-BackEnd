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
   public  class HotelImageService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<HotelImage> HotelImageRepo;
        public HotelImageService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            HotelImageRepo = unitOfWork.HotelImageRepo;
        }
        public HotelImageEditViewModel Add(HotelImageEditViewModel HotelImage)
        {
            HotelImage _HotelImage = HotelImageRepo.Add(HotelImage.toModel());
            unitOfWork.commit();
            return _HotelImage.toEditViewModel();
        }
        public HotelImageEditViewModel Update(HotelImageEditViewModel HotelImage)
        {
            HotelImage _HotelImage = HotelImageRepo.Update(HotelImage.toModel());
            unitOfWork.commit();
            return _HotelImage.toEditViewModel();
        }

        public HotelImageViewModel GetByID(int id)
        {
            HotelImage HotelImage = HotelImageRepo.GetByID(id);
            return HotelImage.toViewModel();
        }

        public IEnumerable<HotelImageViewModel> GetAll()
        {

            return HotelImageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<HotelImageViewModel> GetFilter(int ID)
        {
            var Departments = HotelImageRepo.GetFilter(a => a.ID == ID);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(HotelImageEditViewModel HotelImage)
        {
            HotelImageRepo.Remove(HotelImage.toModel());
            unitOfWork.commit();
        }

    }
}

    