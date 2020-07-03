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
    //[AuthorizeUser(Roles = "Admin")]
    //[AuthorizeUser(Roles = "User")]

    public class HotelController : ApiController
    {
        private readonly HotelService HotelService;
        public HotelController(HotelService service)
        {
            HotelService = service;
        }
        [AuthorizeUser(Roles = "Admin")]
        [HttpGet]
        public ResultViewModels<IEnumerable<HotelViewModel>> AllHotels()
        {
            ResultViewModels<IEnumerable<HotelViewModel>> result
           = new ResultViewModels<IEnumerable<HotelViewModel>>();
            try
            {
                var hotelTemp = HotelService.GetAll();
                if (hotelTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = hotelTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
       // [AuthorizeUser(Roles = "Admin")]

        [HttpGet]
        public ResultViewModels<HotelViewModel> GetHotelByID(int id)
        {
            ResultViewModels<HotelViewModel> result
            = new ResultViewModels<HotelViewModel>();
            try
            {
                var hotelTemp = HotelService.GetByID(id);
                if (hotelTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = hotelTemp;
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
        public ResultViewModels<IEnumerable<HotelViewModel>> FilterHotel(String name)
        {
            ResultViewModels<IEnumerable<HotelViewModel>> result
             = new ResultViewModels<IEnumerable<HotelViewModel>>();
            try
            {
                var hotelTemp = HotelService.GetFilter(name);
                if (hotelTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = hotelTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

             return result;
        }
        [AuthorizeUser(Roles = "Admin")]

        [HttpPost]
        public ResultViewModels<HotelEditViewModel> AddHotel(HotelEditViewModel HotelEditView)
        {
            ResultViewModels<HotelEditViewModel> result
               = new ResultViewModels<HotelEditViewModel>();
            try
            {
                var hotelTemp = HotelService.Add(HotelEditView);
                if (hotelTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = hotelTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [AuthorizeUser(Roles = "Admin")]

        [HttpPost]
        public ResultViewModels<HotelEditViewModel> EditHotel(HotelEditViewModel HotelEditView)
        {
            ResultViewModels<HotelEditViewModel> result
              = new ResultViewModels<HotelEditViewModel>();
            try
            {
                var hotelTemp = HotelService.Update(HotelEditView);
                if (hotelTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = hotelTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;

        }
        [AuthorizeUser(Roles = "Admin")]

        [HttpDelete]
        public ResultViewModels<string> RemoveHotel(int id)
        {
            ResultViewModels<string> result
                = new ResultViewModels<string>();
            try
            {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                HotelService.Remove(id);
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Error Occured";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<HotelViewModel>> Get(int pageIndex ,int pageSize, string name = "")
        {
            ResultViewModels<IEnumerable<HotelViewModel>> result
           = new ResultViewModels<IEnumerable<HotelViewModel>>();
            try
            {
                var hotels =
                 HotelService.Get(pageIndex, pageSize,name);
                if (hotels == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = hotels;
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
        public int getAllHotelsCount()
        {
            return HotelService.GetCount();
        }



    }
}