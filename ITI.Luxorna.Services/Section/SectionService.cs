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
    public class SectionService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Section> SectionRepo;
        public SectionService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SectionRepo = unitOfWork.SectionRepo;
        }
        public SectionEditViewModel Add(SectionEditViewModel Section)
        {
            Section _Section = SectionRepo.Add(Section.toModel());
            unitOfWork.commit();
            return _Section.toEditViewModel();
        }
        public SectionEditViewModel Update(SectionEditViewModel Section)
        {
            Section _Section = SectionRepo.Update(Section.toModel());
            unitOfWork.commit();
            return _Section.toEditViewModel();
        }
        public SectionViewModel GetByID(int id)
        {
            Section Section = SectionRepo.GetByID(id);
            return Section.toViewModel();
        }

        public IEnumerable<SectionViewModel> GetAll()
        {

            return SectionRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<SectionViewModel> GetFilter(string Name)
        {
            var Departments = SectionRepo.GetFilter(a => a.Name == Name);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(SectionEditViewModel Section)
        {
            SectionRepo.Remove(Section.toModel());
            unitOfWork.commit();
        }
    }
}
