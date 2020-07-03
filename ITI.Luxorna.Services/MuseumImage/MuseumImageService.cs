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
    public class MuseumImageService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<MuseumImage> MuseumImageRepo;
        public MuseumImageService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MuseumImageRepo = unitOfWork.MuseumImageRepo;
        }
        public MuseumImageEditViewModel Add(MuseumImageEditViewModel MuseumImage)
        {
            MuseumImage _MuseumImage = MuseumImageRepo.Add(MuseumImage.toModel());
            unitOfWork.commit();
            return _MuseumImage.toEditViewModel();
        }
        public MuseumImageEditViewModel Update(MuseumImageEditViewModel MuseumImage)
        {
            MuseumImage _MuseumImage = MuseumImageRepo.Update(MuseumImage.toModel());
            unitOfWork.commit();
            return _MuseumImage.toEditViewModel();
        }

        public MuseumImageViewModel GetByID(int id)
        {
            MuseumImage MuseumImage = MuseumImageRepo.GetByID(id);
            return MuseumImage.toViewModel();
        }

        public IEnumerable<MuseumImageViewModel> GetAll()
        {

            return MuseumImageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<MuseumImageViewModel> GetFilter(int   ID)
        {
            var Departments = MuseumImageRepo.GetFilter(a => a.ID == ID);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(MuseumImageEditViewModel MuseumImage)
        {
            MuseumImageRepo.Remove(MuseumImage.toModel());
            unitOfWork.commit();
        }

    }
}
