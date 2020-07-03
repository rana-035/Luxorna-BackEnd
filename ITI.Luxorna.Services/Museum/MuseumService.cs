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
    public class MuseumService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Museum> MuseumRepo;
        public MuseumService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            MuseumRepo = unitOfWork.MuseumRepo;
        }
        public MuseumEditViewModel Add(MuseumEditViewModel Museum)
        {
            Museum _Museum = MuseumRepo.Add(Museum.toModel());
            unitOfWork.commit();
            return _Museum.toEditViewModel();
        }
        public MuseumEditViewModel Update(MuseumEditViewModel Museum)
        {
            Museum _Museum = MuseumRepo.Update(Museum.toModel());
            unitOfWork.commit();
            return _Museum.toEditViewModel();
        }

        public MuseumViewModel GetByID(int id)
        {
            Museum Museum = MuseumRepo.GetByID(id);
            return Museum.toViewModel();
        }

        public IEnumerable<MuseumViewModel> GetAll()
        {

            return MuseumRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<MuseumViewModel> GetFilter(string Name)
        {
            var Departments = MuseumRepo.GetFilter(a => a.Name == Name);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(MuseumEditViewModel Museum)
        {
            MuseumRepo.Remove(Museum.toModel());
            unitOfWork.commit();
        }

    }
}

    