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
    public class SizeService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Size> SizeRepo;
        public SizeService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SizeRepo = unitOfWork.SizeRepo;
        }
        public SizeEditViewModel Add(SizeEditViewModel Size)
        {
            Size _Size = SizeRepo.Add(Size.ToModel());
            unitOfWork.commit();
            return _Size.ToEditViewModel();
        }
        public SizeEditViewModel Update(SizeEditViewModel Size)
        {
            Size _Size = SizeRepo.Update(Size.ToModel());
            unitOfWork.commit();
            return _Size.ToEditViewModel();
        }
        public SizeViewModel GetByID(int id)
        {
            Size Size = SizeRepo.GetByID(id);
            return Size.ToViewModel();
        }
        public IEnumerable<SizeViewModel> GetAll()
        {

            return SizeRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SizeViewModel> GetFilter(string size)
        {
            var Departments = SizeRepo.GetFilter(a => a.Name == size);
            return Departments.ToList().Select(i => i.ToViewModel());
        }

        public void Remove(SizeEditViewModel Size)
        {
            SizeRepo.Remove(Size.ToModel());
            unitOfWork.commit();
        }
    }
}
