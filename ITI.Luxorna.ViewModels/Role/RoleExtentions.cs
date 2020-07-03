using ITI.Luxorna.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.ViewModels
{
    public  static class RoleExtentions
    {
        public static RoleViewModel toViewModel(this Role model)
        {
            return new RoleViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                
            };
        }
        public static RoleEditViewModel toEditViewModel(this Role model)
        {
            return new RoleEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                
            };
        }
        public static Role toModel(this RoleEditViewModel model)
        {
            return new Role()
            {
                ID = model.ID,
                Name = model.Name,
                


            };
        }
    }
}
