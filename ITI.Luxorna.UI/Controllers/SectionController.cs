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
    public class SectionController : ApiController
    {
        private readonly SectionService SectionService;
        public SectionController(SectionService service)
        {
            SectionService = service;
        }
        [HttpGet]
        public IEnumerable<SectionViewModel> AllSections()
        {
            return SectionService.GetAll();
        }
        [HttpGet]
        public SectionViewModel GetSectionByID(int id)
        {
            return SectionService.GetByID(id);
        }
        [HttpGet]
        public IEnumerable<SectionViewModel> FilterSection(String Name)
        {
            return SectionService.GetFilter(Name);
        }
        [HttpPost]
        public SectionEditViewModel AddSection(SectionEditViewModel SectionEditView)
        {
            var Section = SectionService.Add(SectionEditView);
            return Section;
        }
        [HttpPost]
        public SectionEditViewModel EditSection(SectionEditViewModel SectionEditView)
        {
            var Section = SectionService.Update(SectionEditView);
            return Section;
        }
        [HttpDelete]
        public void RemoveSection(int id)
        {

            SectionService.Remove(new SectionEditViewModel() { ID = id });

        }
    }
}
