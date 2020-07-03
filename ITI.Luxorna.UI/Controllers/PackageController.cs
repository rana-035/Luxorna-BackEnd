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
   
    public class PackageController : ApiController
    {
        private readonly PackageService packageService;
        public PackageController(PackageService _packageService)
        {
            packageService = _packageService;
        }
        [AuthorizeUser(Roles = "Admin")]
        [HttpGet]
        public ResultViewModels<IEnumerable<PackageViewModel>> AllPackages()
        {
            ResultViewModels<IEnumerable<PackageViewModel>> result
           = new ResultViewModels<IEnumerable<PackageViewModel>>();
            try
            {
                var packageTemp = packageService.GetAll();
                if (packageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = packageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [AuthorizeUser(Roles = "User")]
        [HttpGet]
        public ResultViewModels<PackageViewModel> GetPackageByID(int id)
        {
            ResultViewModels<PackageViewModel> result
             = new ResultViewModels<PackageViewModel>();
            try
            {
                var packageTemp = packageService.GetByID(id);
                if (packageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = packageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<PackageViewModel>> FilterPackage(int id)
        {
            ResultViewModels<IEnumerable<PackageViewModel>> result
             = new ResultViewModels<IEnumerable<PackageViewModel>>();
            try
            {
                var packageTemp = packageService.GetFilter(id);
                if (packageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = packageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [AuthorizeUser(Roles = "User")]
        [HttpGet]
        public ResultViewModels<PagingViewModel> Search
         (int id = 0, string name = "", int pageIndex = 1, int pageSize = 2)
        {
            ResultViewModels<PagingViewModel> result
           = new ResultViewModels<PagingViewModel>();
            try
            {
                var resturants =
                packageService.Get(id, name, pageIndex, pageSize);
                if (resturants == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = resturants;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;


        }
        [AuthorizeUser(Roles = "User")]

        [HttpPost]
        public ResultViewModels<PackageEditViewModel> AddPackage(PackageEditViewModel PackageEditView)
        {
            ResultViewModels<PackageEditViewModel> result
                 = new ResultViewModels<PackageEditViewModel>();
            try
            {
                var packageTemp = packageService.Add(PackageEditView);
                if (packageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = packageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [AuthorizeUser(Roles = "User")]
        [HttpPost]
        public ResultViewModels<PackageEditViewModel> EditPackage(PackageEditViewModel PackageEditView)
        {
            ResultViewModels<PackageEditViewModel> result
             = new ResultViewModels<PackageEditViewModel>();
            try
            {
                var packageTemp = packageService.Update(PackageEditView);
                if (packageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = packageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;

        }
        [AuthorizeUser(Roles = "User")]
        [HttpDelete]
        public ResultViewModels<string> RemovePackage(int id)
        {

            ResultViewModels<string> result
               = new ResultViewModels<string>();
            try
            {
                packageService.Remove(id);
                result.Successed = true;
                result.Message = "Successfully Deleted";
              
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Error Occured";
            }
            return result;

        }

    }
}
