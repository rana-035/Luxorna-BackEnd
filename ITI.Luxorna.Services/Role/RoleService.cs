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
    public class RoleService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Role> RoleRepo;
        public RoleService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            RoleRepo = unitOfWork.RoleRepo;
        }
        public RoleEditViewModel Add(RoleEditViewModel Role)
        {
            Role _Role = RoleRepo.Add(Role.toModel());
            unitOfWork.commit();
            return _Role.toEditViewModel();
        }
        public RoleEditViewModel Update(RoleEditViewModel Role)
        {
            Role _Role = RoleRepo.Update(Role.toModel());
            unitOfWork.commit();
            return _Role.toEditViewModel();
        }
        public RoleViewModel GetByID(int id)
        {
            Role Role = RoleRepo.GetByID(id);
            return Role.toViewModel();
        }

        public IEnumerable<RoleViewModel> GetAll()
        {

            return RoleRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<RoleViewModel> GetFilter(string Name)
        {
            var Departments = RoleRepo.GetFilter(a => a.Name == Name);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(RoleEditViewModel Role)
        {
            RoleRepo.Remove(Role.toModel());
            unitOfWork.commit();
        }
    }
}
