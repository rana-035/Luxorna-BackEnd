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
    public class SizeController : ApiController
    {
        private readonly SizeService SizeService;
        public SizeController(SizeService service)
        {
            SizeService = service;
        }
        [HttpGet]
        public IEnumerable<SizeViewModel> AllSizes()
        {
            return SizeService.GetAll();
        }
        [HttpGet]
        public SizeViewModel GetSizeByID(int id)
        {
            return SizeService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<SizeViewModel> FilterSize(String Name)
        {
            return SizeService.GetFilter(Name);
        }
        [HttpPost]
        public SizeEditViewModel AddSize(SizeEditViewModel SizeEditView)
        {
            var Size = SizeService.Add(SizeEditView);
            return Size;
        }
        [HttpPost]
        public SizeEditViewModel EditSize(SizeEditViewModel SizeEditView)
        {
            var Size = SizeService.Update(SizeEditView);
            return Size;
        }
        [HttpDelete]
        public void RemoveSize(int id)
        {

            SizeService.Remove(new SizeEditViewModel() { ID = id });

        }
    }
}
