using ITI.Luxorna.Entities;
using ITI.Luxorna.Services;
using ITI.Luxorna.ViewModels;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ITI.Luxorna.UI
{
    
    public class AdminController:ApiController
    {
        IHubContext hubContext;
        private readonly AdminService adminService;
        public AdminController (AdminService service)
        {
            adminService = service;
            hubContext=GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        }
        
        [HttpGet]
      
        public IEnumerable<AdminViewModel>AllAdmins()
        {
            return adminService.GetAll();
        }
        [HttpGet]
        public AdminViewModel GetAdminByID( int id )
        {
            return adminService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<AdminViewModel> FilterAdmin(String UserName,string Password)
        {
            return adminService.GetFilter(UserName,Password);
        }
        [HttpPost]
        public AdminEditViewModel AddAdmin(AdminEditViewModel adminEditView)
        {
            var admin = adminService.Add(adminEditView);
            return admin;
        }
        [AuthorizeUser(Roles = "Admin")]

        [HttpPost]
        public AdminEditViewModel EditAdmin(AdminEditViewModel adminEditView)
        {
            var admin = adminService.Update(adminEditView);
            /// hubContext.Clients.All.UpdatedAdmin(admin);
            return admin;
        }
        [HttpDelete]
        public void RemoveAdmin(int id)
        {

            adminService.Remove(new AdminEditViewModel() { ID = id });

        }
       /// [AuthorizeUser(Roles = "Admin")]
        [HttpPost]
        public ResultViewModels<AdminViewModel> Login(AdminViewModel model)
        {
            ResultViewModels<AdminViewModel> result
             = new ResultViewModels<AdminViewModel>();
            try
            {
                var adminTemp = adminService.GetFilter(model.UserName, model.Password).FirstOrDefault();
                if (adminTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Invalid User Name Or Password";
                }
                else
                {
                    result.Successed = true;
                    
                    result.Token = SecurityHelper.GenerateToken(adminTemp);
                    adminTemp.Password = null;
                    result.Data = adminTemp;
                }
            }
            catch(Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }





    }
}