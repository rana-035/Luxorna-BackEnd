using ITI.Luxorna.Services;
using ITI.Luxorna.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ITI.Luxorna.UI
{
    public class TemplePackageController : ApiController
    {
        private readonly TemplePackageService TemplePackageService;
        public TemplePackageController(TemplePackageService service)
        {
            TemplePackageService = service;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<TemplePackageViewModel>> AllTemplePackages()
        {
            ResultViewModels<IEnumerable<TemplePackageViewModel>> result
           = new ResultViewModels<IEnumerable<TemplePackageViewModel>>();
            try
            {
                var templepackageTemp = TemplePackageService.GetAll();
                if (templepackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data ound";
                    result.Data = templepackageTemp;
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
        public ResultViewModels<TemplePackageViewModel> GetTemplePackageByID(int id)
        {
            ResultViewModels<TemplePackageViewModel> result
               = new ResultViewModels<TemplePackageViewModel>();
            try
            {
                var templepackageTemp = TemplePackageService.GetByID(id);
                if (templepackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = templepackageTemp;
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
        public ResultViewModels<IEnumerable<TemplePackageViewModel>> FilterTemplePackage(string name)
        {
            ResultViewModels<IEnumerable<TemplePackageViewModel>> result
              = new ResultViewModels<IEnumerable<TemplePackageViewModel>>();
            try
            {
                var templepackageTemp = TemplePackageService.GetFilter(name);
                if (templepackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = templepackageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [HttpPost]
        public ResultViewModels<TemplePackageEditViewModel> AddTemplePackage(TemplePackageEditViewModel TemplePackageEditView)
        {
            ResultViewModels<TemplePackageEditViewModel> result
                  = new ResultViewModels<TemplePackageEditViewModel>();
            try
            {
                var templepackageTemp = TemplePackageService.Add(TemplePackageEditView);
                if (templepackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = templepackageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [HttpPost]
        public ResultViewModels<TemplePackageEditViewModel> EditTemplePackage(TemplePackageEditViewModel TemplePackageEditView)
        {
            ResultViewModels<TemplePackageEditViewModel> result
              = new ResultViewModels<TemplePackageEditViewModel>();
            try
            {
                var templepackageTemp = TemplePackageService.Update(TemplePackageEditView);
                if (templepackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = templepackageTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;

        }
        [HttpDelete]
        public ResultViewModels<string> RemoveTemplePackage(int id)
        {

            ResultViewModels<string> result
              = new ResultViewModels<string>();
            try
            {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                TemplePackageService.Remove(id);
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
