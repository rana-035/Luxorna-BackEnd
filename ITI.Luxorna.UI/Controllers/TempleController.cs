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
    ////[AuthorizeUser(Roles = "Admin,User")]
    public class TempleController : ApiController
    {
        private readonly TempleService TempleService;
        public TempleController(TempleService service)
        {
            TempleService = service;
        }
        [AuthorizeUser(Roles = "Admin")]

        [HttpGet]
        public ResultViewModels<IEnumerable<TempleViewModel>> AllTemples()
        {
            ResultViewModels<IEnumerable<TempleViewModel>> result
             = new ResultViewModels<IEnumerable<TempleViewModel>>();
            try
            {
                var TempleTemp = TempleService.GetAll();
                if (TempleTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = TempleTemp;
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
        public ResultViewModels<TempleViewModel> GetTempleByID(int id)
        {
            ResultViewModels<TempleViewModel> result
            = new ResultViewModels<TempleViewModel>();
            try
            {
                var TempleTemp = TempleService.GetByID(id);
                if (TempleTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = TempleTemp;
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
        public ResultViewModels<IEnumerable<TempleViewModel>> FilterTemple(String name)
        {
            ResultViewModels<IEnumerable<TempleViewModel>> result
            = new ResultViewModels<IEnumerable<TempleViewModel>>();
            try
            {
                var TempleTemp = TempleService.GetFilter(name);
                if (TempleTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = TempleTemp;
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
        public ResultViewModels<TempleEditViewModel> AddTemple(TempleEditViewModel TempleEditView)
        {
            ResultViewModels<TempleEditViewModel> result
              = new ResultViewModels<TempleEditViewModel>();
            try
            {
                var TempleTemp = TempleService.Add(TempleEditView);
                if (TempleTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data added";
                    result.Data = TempleTemp;
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
        public ResultViewModels<TempleEditViewModel> EditTemple(TempleEditViewModel TempleEditView)
        {
            ResultViewModels<TempleEditViewModel> result
              = new ResultViewModels<TempleEditViewModel>();
            try
            {
                var TempleTemp = TempleService.Update(TempleEditView);
                if (TempleTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Data is empty";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "Data Updated";
                    result.Data = TempleTemp;
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
        public ResultViewModels<string> RemoveTemple(int id)
        {
            ResultViewModels<string> result
                = new ResultViewModels<string>();
            try
            {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                TempleService.Remove(id);
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Error Occured";
            }
            return result;
        }
        [HttpGet]
        public ResultViewModels<IEnumerable<TempleViewModel>> Get(int pageIndex,int pageSize,string name="")
        {
            ResultViewModels<IEnumerable<TempleViewModel>> result
           = new ResultViewModels<IEnumerable<TempleViewModel>>();
            try
            {
                var temples =
                 TempleService.Get(pageIndex, pageSize, name);
                if (temples == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = temples;
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

        public int getAllTemplesCount()
        {
            return TempleService.GetCount();
        }

    }
}
