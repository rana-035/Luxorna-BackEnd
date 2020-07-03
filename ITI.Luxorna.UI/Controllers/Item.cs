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
    public class ItemController : ApiController
    {
        private readonly ItemService ItemService;
        public ItemController(ItemService _resturantMenuItemService)
        {
            ItemService = _resturantMenuItemService;
        }
        [HttpGet]
        public IEnumerable<ItemViewModel> AllResturantMenuItems()
        {
            return ItemService.GetAll();
        }
        [HttpGet]
        public ItemViewModel GetResturantMenuItemByID(int id)
        {
            return ItemService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<ItemViewModel> FilterResturantMenuItem(string itemName)
        {
            return ItemService.GetFilter(itemName);
        }
        [HttpPost]
        public ItemEditViewModel AddResturantMenuItem(ItemEditViewModel ResturantMenuItemEditView)
        {
            var ResturantMenuItem = ItemService.Add(ResturantMenuItemEditView);
            return ResturantMenuItem;
        }
        public ItemEditViewModel EditResturantMenuItem(ItemEditViewModel ResturantMenuItemEditView)
        {
            var ResturantMenuItem = ItemService.Update(ResturantMenuItemEditView);
            return ResturantMenuItem;
        }
        [HttpDelete]
        public void RemoveResturantMenuItem(int id)
        {

            ItemService.Remove(new ItemEditViewModel() { ID = id });

        }
        [HttpGet]
        public ResultViewModels<IEnumerable<ItemEditViewModel>> Get(int pageIndex ,int pageSize, int ResturantID)
        {
            ResultViewModels<IEnumerable<ItemEditViewModel>> result
           = new ResultViewModels<IEnumerable<ItemEditViewModel>>();
            try
            {
                var resturants =
                 ItemService.Get(pageIndex, pageSize, ResturantID);
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

        public int getAllItemsCount()
        {
            return ItemService.GetCount();
        }



        [HttpGet]
        public ResultViewModels<PagingViewModel> Search
           (int id = 0, string name = "", int sizeId = 0, int ResturantID = 0, int pageIndex = 1, int pageSize = 2)
        {
            ResultViewModels<PagingViewModel> result
           = new ResultViewModels<PagingViewModel>();
            try
            {
                var resturants =
                 ItemService.Get(id,name,sizeId, ResturantID, pageIndex, pageSize);
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
    }
}
