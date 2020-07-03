using ITI.Luxorna.Services;
using ITI.Luxorna.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.Luxorna.UI
{
    public class RoleController : ApiController
    {
        private readonly RoleService RoleService;
        public RoleController(RoleService service)
        {
            RoleService = service;
        }
        [HttpGet]
        public IEnumerable<RoleViewModel> AllRoles()
        {
            return RoleService.GetAll();
        }
        [HttpGet]
        public RoleViewModel GetRoleByID(int id)
        {
            return RoleService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<RoleViewModel> FilterRole(String Name)
        {
            return RoleService.GetFilter(Name);
        }
        [HttpPost]
        public RoleEditViewModel AddRole(RoleEditViewModel RoleEditView)
        {
            var Role = RoleService.Add(RoleEditView);
            return Role;
        }
        [HttpPost]
        public RoleEditViewModel EditRole(RoleEditViewModel RoleEditView)
        {
            var Role = RoleService.Update(RoleEditView);
            return Role;
        }
        [HttpDelete]
        public void RemoveRole(int id)
        {

            RoleService.Remove(new RoleEditViewModel() { ID = id });

        }
    }
}
