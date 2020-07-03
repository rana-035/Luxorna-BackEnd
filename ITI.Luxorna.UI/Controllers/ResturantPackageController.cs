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
    public class ResturantPackageController : ApiController
    {
        private readonly ResturantPackageService resturantPackageService;
        public ResturantPackageController(ResturantPackageService _resturantPackageService)
        {
            resturantPackageService = _resturantPackageService;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<ResturantPackageViewModel>> AllResturantPackages()
        {
            ResultViewModels<IEnumerable<ResturantPackageViewModel>> result
            = new ResultViewModels<IEnumerable<ResturantPackageViewModel>>();
            try
            {
                var resturantpackageTemp = resturantPackageService.GetAll();
                if (resturantpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data ound";
                    result.Data = resturantpackageTemp;
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
        public ResultViewModels<ResturantPackageViewModel> GetResturantPackageByID(int id)
        {
            ResultViewModels<ResturantPackageViewModel> result
               = new ResultViewModels<ResturantPackageViewModel>();
            try
            {
                var resturantpackageTemp = resturantPackageService.GetByID(id);
                if (resturantpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = resturantpackageTemp;
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
        public ResultViewModels<IEnumerable<ResturantPackageViewModel>> FilterResturantPackage(string name)
        {
            ResultViewModels<IEnumerable<ResturantPackageViewModel>> result
              = new ResultViewModels<IEnumerable<ResturantPackageViewModel>>();
            try
            {
                var resturantpackageTemp = resturantPackageService.GetFilter(name);
                if (resturantpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = resturantpackageTemp;
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
        public ResultViewModels<ResturantPackageEditViewModel> AddResturantPackage(ResturantPackageEditViewModel ResturantPackageEditView)
        {
            ResultViewModels<ResturantPackageEditViewModel> result
                   = new ResultViewModels<ResturantPackageEditViewModel>();
            try
            {
                var resturantpackageTemp = resturantPackageService.Add(ResturantPackageEditView);
                if (resturantpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = resturantpackageTemp;
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
        public ResultViewModels<ResturantPackageEditViewModel> EditResturantPackage(ResturantPackageEditViewModel ResturantPackageEditView)
        {
            ResultViewModels<ResturantPackageEditViewModel> result
              = new ResultViewModels<ResturantPackageEditViewModel>();
            try
            {
                var resturantpackageTemp = resturantPackageService.Update(ResturantPackageEditView);
                if (resturantpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = resturantpackageTemp;
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
        public ResultViewModels<string> RemoveResturantPackage(int id)
        {

            ResultViewModels<string> result
             = new ResultViewModels<string>();
            try
            {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                resturantPackageService.Remove(id);
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
