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
   public  class AdminService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Admin> AdminRepo;
        public AdminService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            AdminRepo = unitOfWork.AdminRepo;
        }
        public AdminEditViewModel Add(AdminEditViewModel admin )
        {
            Admin _admin = AdminRepo.Add(admin.toModel());
            unitOfWork.commit();
            return _admin.toEditViewModel();
        }
        public AdminEditViewModel Update(AdminEditViewModel admin)
        {
            Admin _admin = AdminRepo.Update(admin.toModel());
            unitOfWork.commit();
            return _admin.toEditViewModel();
        }
        public  AdminViewModel GetByID(int id)
        {
            Admin admin = AdminRepo.GetByID(id);
            return admin.toViewModel();
        }

        public IEnumerable<AdminViewModel> GetAll()
        {

            return AdminRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<AdminViewModel> GetFilter(string UserName,string Password)
        {
            var Admins = AdminRepo.GetFilter(a => a.UserName == UserName && a.Password==Password);
            return Admins.ToList().Select(i => i.toViewModel());
        }

        public void Remove(AdminEditViewModel admin)
        {
            AdminRepo.Remove(admin.toModel());
            unitOfWork.commit();
        }







    }
}
