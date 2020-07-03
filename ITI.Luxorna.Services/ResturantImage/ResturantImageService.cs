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
    public class ResturantImageService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<ResturantImage> ResturantImageRepo;
        public ResturantImageService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ResturantImageRepo = unitOfWork.ResturantImageRepo;
        }
        public ResturantImageEditViewModel Add(ResturantImageEditViewModel _ResturantImage)
        {
            ResturantImage ResturantImage =ResturantImageRepo.Add(_ResturantImage.ToModel());
            UnitOfWork.commit();
            return ResturantImage.ToEditViewModel();
        }
        public ResturantImageEditViewModel Update(ResturantImageEditViewModel _ResturantImage)
        {
            ResturantImage ResturantImage =ResturantImageRepo.Add(_ResturantImage.ToModel());
            UnitOfWork.commit();
            return ResturantImage.ToEditViewModel();
        }
        public ResturantImageViewModel GetByID(int id)
        {
            ResturantImage _ResturantImage = ResturantImageRepo.GetByID(id);
            return _ResturantImage.toViewModel();
        }

        public IEnumerable<ResturantImageViewModel> GetAll()
        {

            return ResturantImageRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<ResturantImageViewModel> GetFilter(string image)
        {
            var ResturantImages =ResturantImageRepo.GetFilter(a => a.Image== image);
            return ResturantImages.ToList().Select(i => i.toViewModel());
        }

        public void Remove(ResturantImageEditViewModel admin)
        {
           ResturantImageRepo.Remove(admin.ToModel());
            UnitOfWork.commit();
        }
    }
    }

