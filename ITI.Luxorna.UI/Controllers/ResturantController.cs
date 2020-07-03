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
   //// [AuthorizeUser(Roles = "Admin,User")]
    public class ResturantController : ApiController
    {
        private readonly ResturantService resturantService;
        public ResturantController(ResturantService _resturantService)
        {
            resturantService = _resturantService;
        }
        [AuthorizeUser(Roles = "Admin")]

        [HttpGet]
        public ResultViewModels<IEnumerable<ResturantViewModel>> AllResturants()
        {
            ResultViewModels<IEnumerable<ResturantViewModel>> result
           = new ResultViewModels<IEnumerable<ResturantViewModel>>();
            try
            {
                var restaurantTemp = resturantService.GetAll();
                if (restaurantTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = restaurantTemp;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                result.Message = ex.Message;
            }

            return result;
        }
    

            
        
        [HttpGet]
        public ResultViewModels<ResturantEditViewModel> GetResturantByID(int id)
        {
            ResultViewModels<ResturantEditViewModel> result
            = new ResultViewModels<ResturantEditViewModel>();
            try
            {
                var restaurantTemp = resturantService.GetID(id);
                if (restaurantTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = restaurantTemp;
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
        //    public ResultViewModels<ResturantViewModel> FilterResturant(string name)
        //    {
        //        ResultViewModels<IEnumerable< ResturantViewModel> > result
        //         = new ResultViewModels<IEnumerable<ResturantViewModel>>();
        //        try
        //        {
        //            var restaurantTemp = resturantService.GetFilter(name);
        //            if (restaurantTemp == null)
        //            {
        //                result.Successed = false;
        //                result.Message = "No Data Found";
        //            }
        //            else
        //            {
        //                result.Successed = true;

        //                result.Message = "All Data Found";
        //                result.Data = restaurantTemp;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            result.Successed = false;
        //            result.Message = "Something Went Wrong !!";
        //        }

        //       // return result;
        //    }
        [AuthorizeUser(Roles = "Admin")]

        [HttpPost]
        public ResultViewModels<ResturantEditViewModel> AddResturant(ResturantEditViewModel ResturantEditView)
        {
            ResultViewModels<ResturantEditViewModel> result
              = new ResultViewModels<ResturantEditViewModel>();
            try
            {
                var restaurantTemp = resturantService.Add(ResturantEditView);
                if (restaurantTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = restaurantTemp;
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
        public ResultViewModels<ResturantEditViewModel> EditResturant(ResturantEditViewModel ResturantEditView)
        {
            ResultViewModels<ResturantEditViewModel> result
              = new ResultViewModels<ResturantEditViewModel>();
            try
            {
                var restaurantTemp = resturantService.Update(ResturantEditView);
                if (restaurantTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = restaurantTemp;
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
        public ResultViewModels<string> RemoveResturant(int id)
        {
            ResultViewModels<string> result
                = new ResultViewModels<string>();
            try {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                resturantService.Remove(id);
            }
            catch(Exception ex)
            {
                result.Successed = false;
                result.Message = "Error Occured";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<ResturantViewModel>> Get(int pageIndex,int pageSize,string name="")
        {
            ResultViewModels<IEnumerable<ResturantViewModel>> result
           = new ResultViewModels<IEnumerable<ResturantViewModel>>();
            try
            {
                var resturants =
                 resturantService.Get(pageIndex, pageSize,name);
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
        [HttpGet]

        public int getAllResturantsCount()
        {
            return resturantService.GetCount();
        }
    }
}
