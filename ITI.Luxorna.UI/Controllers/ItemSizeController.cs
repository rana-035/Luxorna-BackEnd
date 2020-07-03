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
    public class ItemSizeController : ApiController
    {
        private readonly ItemSizeService resturantItemSizeService;
        public ItemSizeController(ItemSizeService _resturantItemSizeService)
        {
            resturantItemSizeService = _resturantItemSizeService;
        }
        [HttpGet]
        public IEnumerable<ItemSizeViewModel> AllResturantItemSizes()
        {
            return resturantItemSizeService.GetAll();
        }
        [HttpGet]
        public ItemSizeViewModel GetResturantItemSizeByID(int id)
        {
            return resturantItemSizeService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<ItemSizeViewModel> FilterResturantItemSize(int id)
        {
            return resturantItemSizeService.GetFilter(id);
        }
        [HttpPost]
        public ItemSizeEditViewModel AddResturantItemSize(ItemSizeEditViewModel ResturantItemSizeEditView)
        {
            var ResturantItemSize = resturantItemSizeService.Add(ResturantItemSizeEditView);
            return ResturantItemSize;
        }
        public ItemSizeEditViewModel EditResturantItemSize(ItemSizeEditViewModel ResturantItemSizeEditView)
        {
            var ResturantItemSize = resturantItemSizeService.Update(ResturantItemSizeEditView);
            return ResturantItemSize;
        }
        [HttpDelete]
        public void RemoveResturantItemSize(int id)
        {

            resturantItemSizeService.Remove(new ItemSizeEditViewModel() { ID = id });

        }
    }
}
