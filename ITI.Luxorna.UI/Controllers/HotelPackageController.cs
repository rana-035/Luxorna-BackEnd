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
    public class HotelPackageController : ApiController
    {
        private readonly HotelPackageService HotelPackageService;
        public HotelPackageController(HotelPackageService service)
        {
            HotelPackageService = service;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<HotelPackageViewModel>> AllHotelPackages()
        {
            ResultViewModels<IEnumerable<HotelPackageViewModel>> result
           = new ResultViewModels<IEnumerable<HotelPackageViewModel>>();
            try
            {
                var hotelpackageTemp = HotelPackageService.GetAll();
                if (hotelpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = hotelpackageTemp;
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
        public ResultViewModels<HotelPackageViewModel> GetHotelPackageByID(int id)
        {
            ResultViewModels<HotelPackageViewModel> result
               = new ResultViewModels<HotelPackageViewModel>();
            try
            {
                var hotelpackageTemp = HotelPackageService.GetByID(id);
                if (hotelpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = hotelpackageTemp;
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
        public ResultViewModels<IEnumerable<HotelPackageViewModel>> FilterHotelPackage(string name)
        {
            ResultViewModels<IEnumerable<HotelPackageViewModel>> result
              = new ResultViewModels<IEnumerable<HotelPackageViewModel>>();
            try
            {
                var hotelpackageTemp = HotelPackageService.GetFilter(name);
                if (hotelpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = hotelpackageTemp;
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
        public ResultViewModels<HotelPackageEditViewModel> AddHotelPackage(HotelPackageEditViewModel HotelPackageEditView)
        {
            ResultViewModels<HotelPackageEditViewModel> result
                 = new ResultViewModels<HotelPackageEditViewModel>();
            try
            {
                var hotelpackageTemp = HotelPackageService.Add(HotelPackageEditView);
                if (hotelpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = hotelpackageTemp;
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
        public ResultViewModels<HotelPackageEditViewModel> EditHotelPackage(HotelPackageEditViewModel HotelPackageEditView)
        {
            ResultViewModels<HotelPackageEditViewModel> result
             = new ResultViewModels<HotelPackageEditViewModel>();
            try
            {
                var hotelpackageTemp = HotelPackageService.Update(HotelPackageEditView);
                if (hotelpackageTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = hotelpackageTemp;
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
        public ResultViewModels<string> RemoveHotelPackage(int id)
        {

            ResultViewModels<string> result
              = new ResultViewModels<string>();
            try
            {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                HotelPackageService.Remove(id);
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


