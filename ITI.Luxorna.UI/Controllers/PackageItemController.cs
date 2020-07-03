using ITI.Luxorna.Services;
using ITI.Luxorna.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.Luxorna.UI.Controllers
{
    public class PackageItemController : ApiController
    {
        private readonly PackageItemService PackageItemService;
        public PackageItemController(PackageItemService _PackageItemService)
        {
            PackageItemService = _PackageItemService;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<PackageItemViewModel>> AllPackageItems()
        {
            ResultViewModels<IEnumerable<PackageItemViewModel>> result
            = new ResultViewModels<IEnumerable<PackageItemViewModel>>();
            try
            {
                var PackageItemTemp = PackageItemService.GetAll();
                if (PackageItemTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data ound";
                    result.Data = PackageItemTemp;
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
        public ResultViewModels<PackageItemViewModel> GetPackageItemByID(int id)
        {
            ResultViewModels<PackageItemViewModel> result
               = new ResultViewModels<PackageItemViewModel>();
            try
            {
                var PackageItemTemp = PackageItemService.GetByID(id);
                if (PackageItemTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = PackageItemTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        //[HttpGet]
        //public ResultViewModels<IEnumerable<PackageItemViewModel>> FilterPackageItem(string name)
        //{
        //    ResultViewModels<IEnumerable<PackageItemViewModel>> result
        //      = new ResultViewModels<IEnumerable<PackageItemViewModel>>();
        //    try
        //    {
        //        var PackageItemTemp = PackageItemService.GetFilter(name);
        //        if (PackageItemTemp == null)
        //        {
        //            result.Successed = false;
        //            result.Message = "No Data Found";
        //        }
        //        else
        //        {
        //            result.Successed = true;

        //            result.Message = "All Data Found";
        //            result.Data = PackageItemTemp;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Successed = false;
        //        result.Message = "Something Went Wrong !!";
        //    }

        //    return result;
        //}
        [HttpPost]
        public ResultViewModels<PackageItemEditViewModel> AddPackageItem(PackageItemEditViewModel PackageItemEditView)
        {
            ResultViewModels<PackageItemEditViewModel> result
                   = new ResultViewModels<PackageItemEditViewModel>();
            try
            {
                var PackageItemTemp = PackageItemService.Add(PackageItemEditView);
                if (PackageItemTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = PackageItemTemp;
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
        public ResultViewModels<PackageItemEditViewModel> EditPackageItem(PackageItemEditViewModel PackageItemEditView)
        {
            ResultViewModels<PackageItemEditViewModel> result
              = new ResultViewModels<PackageItemEditViewModel>();
            try
            {
                var PackageItemTemp = PackageItemService.Update(PackageItemEditView);
                if (PackageItemTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = PackageItemTemp;
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
        public ResultViewModels<string> RemovePackageItem(int id)
        {

            ResultViewModels<string> result
             = new ResultViewModels<string>();
            try
            {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                PackageItemService.Remove(id);
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
