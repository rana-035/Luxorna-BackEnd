using ITI.Luxorna.Entities;
using ITI.Luxorna.Services;
using ITI.Luxorna.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ITI.Luxorna.UI
{
    public class UserController : ApiController
    {
        private readonly UserService userService;
        //private int counter = 0;
        
        public UserController(UserService service)
        {
            userService = service;
        }
        [AuthorizeUser(Roles = "Admin")]

        [HttpGet]
        public int AllVisitors()
        {
            return StaticData.VisitorsCount;
        }
        [AuthorizeUser(Roles = "Admin")]
        [HttpGet]
        public ResultViewModels<IEnumerable<UserViewModel>> AllUsers()
        {
            ResultViewModels<IEnumerable<UserViewModel>> result
           = new ResultViewModels<IEnumerable<UserViewModel>>();
            try
            {
                var userTemp = userService.GetAll();
                if (userTemp == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = userTemp;
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
        public ResultViewModels<UserEditViewModel> GetUserByID(int id)
        {
            ResultViewModels<UserEditViewModel> result
               = new ResultViewModels<UserEditViewModel>();
            try
            {
                var user = userService.GetByID(id);
                if (user == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = user;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        //[HttpPost]
        //public ResultViewModels<IEnumerable<UserEditViewModel>> GetFoundFilter(UserEditViewModel userModel)
        //{
        //    ResultViewModels<IEnumerable<UserEditViewModel>> result
        //          = new ResultViewModels<IEnumerable<UserEditViewModel>>();
        //    try
        //    {
        //        var user = userService.GetByUserName(userModel.UserName, userModel.Email);
        //        if (user == null)
        //        {
        //            result.Successed = false;
        //            result.Message = "No Data Found";
        //        }
        //        else
        //        {
        //            result.Successed = true;

        //            result.Message = "All Data Found";
        //            result.Data = user;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Successed = false;
        //        result.Message = "Something Went Wrong !!";
        //    }

        //    return result;
        //}
        [AuthorizeUser(Roles = "Admin")]

        [HttpGet]
        public ResultViewModels<IEnumerable<UserViewModel>> FilterUser()
        {
            DateTime startDate,  endDate;
            endDate = DateTime.Now;
            startDate = DateTime.Today.AddDays(-1);

            ResultViewModels<IEnumerable<UserViewModel>> result
                 = new ResultViewModels<IEnumerable<UserViewModel>>();
            try
            {
                var user = userService.GetFilter(startDate, endDate);
                if (user == null)
                {
                    result.Successed = false;
                    result.Message = "No Data Found";
                }
                else
                {
                    result.Successed = true;

                    result.Message = "All Data Found";
                    result.Data = user;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
            //return UserService.GetFilter(Name,Password);
        }

        [HttpPost]
        public ResultViewModels<UserEditViewModel> AddUser(UserEditViewModel UserEditView)
        {
            ResultViewModels<UserEditViewModel> result
               = new ResultViewModels<UserEditViewModel>();
            try
            {
                if (userService.GetByUserName(UserEditView.UserName,UserEditView.Email))
                {
                    result.Successed = false;
                    result.Message = "Already Exist";
                }
                else
                {
                    var user = userService.Add(UserEditView);
                    if (user == null)
                    {
                        result.Successed = false;
                        result.Message = "Data is empty";
                    }
                    else
                    {
                        result.Successed = true;

                        result.Message = "Data added";
                        result.Data = user;
                        //Login(user);
                    }
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
        public ResultViewModels<UserEditViewModel> EditUser(UserEditViewModel UserEditView)
        {
            ResultViewModels<UserEditViewModel> result
              = new ResultViewModels<UserEditViewModel>();
            try
            {
                


                ////if (userService.GetUserNameForUpdate(UserEditView.UserName, UserEditView.Email,UserEditView.ID))
                ////{
                ////    result.Successed = false;
                ////    result.Message = "Already Exist";
                ////}
                ////else
                ////{
                    var user = userService.Update(UserEditView);
                    if (user == null)
                    {
                        result.Successed = false;
                        result.Message = "Data is empty";
                    }
                    else
                    {
                        result.Successed = true;

                        result.Message = "Data Updated";
                        result.Data = user;
                    }
                //}
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
        [HttpDelete]
        public ResultViewModels<string> RemoveUser(int id)
        {

            ResultViewModels<string> result
              = new ResultViewModels<string>();
            try
            {

                result.Successed = true;
                result.Message = "Successfully Deleted";
                userService.Remove(id);
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Error Occured";
            }
            return result;

        }
        [HttpPost]
        public ResultViewModels<UserViewModel> Login(UserEditViewModel model)
        {
            ResultViewModels<UserViewModel> result
             = new ResultViewModels<UserViewModel>();
            try
            {
                var userTemp = userService.GetFilter(model.UserName, model.Password).FirstOrDefault();
                if (userTemp == null)
                {
                    result.Successed = false;
                    result.Message = "Invalid User Name Or Password";
                }
                else
                {
                    result.Successed = true;

                    result.Token = SecurityHelper.GenerateUserToken(userTemp);
                    userTemp.Password = null;
                    result.Data = userTemp;

                    StaticData.VisitorsCount += 1;
                }
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something Went Wrong !!";
            }

            return result;
        }
    }
   

}

