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
    public class MuseumPackageService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<MuseumPacakge> museumPacakgeRepo;
        public MuseumPackageService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            museumPacakgeRepo = unitOfWork.MuseumPackageRepo;
        }
        public MuseumPackageEditViewModel Add(MuseumPackageEditViewModel museumPacakge)
        {
            MuseumPacakge _museumPacakge = museumPacakgeRepo.Add(museumPacakge.toModel());
            UnitOfWork.commit();
            return _museumPacakge.toEditViewModel();
        }
        public MuseumPackageEditViewModel Update(MuseumPackageEditViewModel museumPacakge)
        {
            MuseumPacakge _museumPacakge = museumPacakgeRepo.Add(museumPacakge.toModel());
            UnitOfWork.commit();
            return _museumPacakge.toEditViewModel();
        }
        public MuseumPackageViewModel GetByID(int id)
        {
            MuseumPacakge _museumPacakge = museumPacakgeRepo.GetByID(id);
            return _museumPacakge.toViewModel();
        }

        public IEnumerable<MuseumPackageViewModel> GetAll()
        {

            return museumPacakgeRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<MuseumPackageViewModel> GetFilter(string name)
        {
            var museumPacakges = museumPacakgeRepo.GetFilter(a => a.Package.Name == name);
            return museumPacakges.ToList().Select(i => i.toViewModel());
        }

        public void Remove(MuseumPackageEditViewModel admin)
        {
            museumPacakgeRepo.Remove(admin.toModel());
            UnitOfWork.commit();
        }
    }
}
