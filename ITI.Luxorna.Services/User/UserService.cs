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
    public class UserService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<User> UserRepo;
        public UserService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepo = unitOfWork.UserRepo;
        }
        public UserEditViewModel Add(UserEditViewModel User)
        {
            User _User = UserRepo.Add(User.toModel());
            unitOfWork.commit();
            return _User.toEditViewModel();
        }
        public UserEditViewModel Update(UserEditViewModel User)
        {
            User _User = UserRepo.Update(User.toModel());
            _User.UpdateDate = DateTime.Now;
            unitOfWork.commit();
            return _User.toEditViewModel();
        }
        public UserEditViewModel GetByID(int id)
        {
            User User = UserRepo.GetByID(id);
            return User.toEditViewModel();
        }

        public IEnumerable<UserViewModel> GetAll()
        {

            return UserRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<UserViewModel> GetFilter(  DateTime startDate, DateTime endDate)
        {
            var Users = UserRepo.GetFilter(a => a.CreateDate>=startDate && a.CreateDate<=endDate);
            return Users?.ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<UserViewModel> GetFilter(string UserName,string Password)
        {
            var Users = UserRepo.GetFilter(a => a.UserName == UserName && a.Password==Password);
            return Users.ToList().Select(i => i.toViewModel());
        }
        public bool GetByUserName(string UserName ,string Email)
        {
            var Users = UserRepo.GetAll().Any(a => a.UserName.ToLower() == UserName.ToLower() || a.Email.ToLower() == Email.ToLower());
            return Users;
        }
        public bool GetUserNameForUpdate(string UserName, string Email,int ID)
        {
            var Users = UserRepo.GetAll().Any(a => (a.UserName.ToLower() == UserName.ToLower() || a.Email.ToLower() == Email.ToLower() )&& a.ID!=ID);
            return Users;
        }

        public void Remove(int id)
        {
            UserRepo.Remove(UserRepo.GetFilter(i => i.ID == id).First());
            unitOfWork.commit();
        }
    }
}
