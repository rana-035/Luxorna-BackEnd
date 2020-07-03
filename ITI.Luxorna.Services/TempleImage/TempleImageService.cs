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
    public class TempleImageService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<TempleImage> TempleImageRepo;
        public TempleImageService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TempleImageRepo = unitOfWork.TempleImageRepo;
        }
        public TempleImageEditViewModel Add(TempleImageEditViewModel TempleImage)
        {
            TempleImage _TempleImage = TempleImageRepo.Add(TempleImage.toModel());
            unitOfWork.commit();
            return _TempleImage.toEditViewModel();
        }
        public TempleImageEditViewModel Update(TempleImageEditViewModel TempleImage)
        {
            TempleImage _TempleImage = TempleImageRepo.Update(TempleImage.toModel());
            unitOfWork.commit();
            return _TempleImage.toEditViewModel();
        }
        public TempleImageViewModel GetByID(int id)
        {
            TempleImage TempleImage = TempleImageRepo.GetByID(id);
            return TempleImage.toViewModel();
        }

        public IEnumerable<TempleImageViewModel> GetAll()
        {

            return TempleImageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<TempleImageViewModel> GetFilter(string Image)
        {
            var Departments = TempleImageRepo.GetFilter(a => a.Image == Image);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(TempleImageEditViewModel TempleImage)
        {
            TempleImageRepo.Remove(TempleImage.toModel());
            unitOfWork.commit();
        }
    }
}
