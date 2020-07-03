using ITI.Luxorna.Entities;
using ITI.Luxorna.Repositories;
using ITI.Luxorna.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Luxorna.Services
{
    public class TempleService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Temple> TempleRepo;
        private GenericRepository<TempleImage> TempleImageRepo;
        public TempleService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            TempleRepo = unitOfWork.TempleRepo;
            TempleImageRepo = unitOfWork.TempleImageRepo;
        }
        public TempleEditViewModel Add(TempleEditViewModel Temple)
        {
            Temple _Temple = TempleRepo.Add(Temple.toModel());
            unitOfWork.commit();
            if (Temple.TempleImages != null && Temple.TempleImages.Count() > 0)
                foreach (var image in Temple.TempleImages)
                {
                    image.TempleID = _Temple.ID;
                    TempleImageRepo.Add(image.toModel());
                }
            unitOfWork.commit();

            return _Temple.toEditViewModel();
        }
        public TempleEditViewModel Update(TempleEditViewModel Temple)
        {
            Temple _Temple = TempleRepo.Update(Temple.toModel());
            if (Temple.TempleImages != null && Temple.TempleImages.Count() > 0)
            {
                var toAdd = Temple.TempleImages.Where(i => i.ID == 0);
                foreach (var image in toAdd)
                    TempleImageRepo.Add(image.toModel());

                var toUpdate = Temple.TempleImages.Where(i => i.ID > 0);
                foreach (var image in toUpdate)
                    TempleImageRepo.Update(image.toModel());

                int[] ids = Temple.TempleImages.Select(x => x.ID).ToArray();
                var toDelete = TempleImageRepo.GetFilter(i => !ids.Contains(i.ID) && i.TempleID == Temple.ID);
                foreach (var image in toDelete)
                    TempleImageRepo.Remove(image);
              

            }
            unitOfWork.commit();
            return _Temple.toEditViewModel();
        }
        public TempleViewModel GetByID(int id)
        {
            Temple _Temple = TempleRepo.GetByID(id);
            var TempleViewModel = _Temple?.toViewModel();

            if (_Temple != null)
            {
                TempleViewModel.SectionName = _Temple?.Section.Name;
                TempleViewModel.TempleImages
                        = _Temple?.TempleImages
                        ?.Select(i => i.toViewModel());
            }
            return TempleViewModel;


        }
        public IEnumerable<TempleViewModel> GetAll()
        {

            return TempleRepo.GetAll().Select(i => new TempleViewModel
            {
                ID = i.ID,
                Name = i.Name,
                Description = i.Description,
                Address = i.Address,
                SectionName = i.Section.Name

            }
            ).ToList();
        }
        public IEnumerable<TempleViewModel> GetFilter(string name)
        {
            var Temples = TempleRepo.GetFilter(a => a.Name == name);
            return Temples.ToList().Select(i => i.toViewModel());
        }
        public void Remove(int id)
        {
            TempleRepo.Remove(TempleRepo.GetFilter(i => i.ID == id).First()
               );
            unitOfWork.commit();
        }
        public IEnumerable<TempleViewModel> Get(int pageIndex, int pageSize,string name="")
        {
            //int pageSize = 3;
           var query =
               TempleRepo.GetAll().Select(i => new TempleViewModel
               {
                   ID = i.ID,
                   Name = i.Name,
                   Description = i.Description,
                   Address = i.Address,
                   SectionName = i.Section.Name,
                  TempleImages = i?.TempleImages?.Select(x => x.toViewModel()),
                  TicketPrice = i.TicketPrice


               }
           ).ToList();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();
            var query2 = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query2.ToList();
        }
        public int GetCount()
        {
            var query =
               TempleRepo.GetAll();
            return query.Count();

        }
    }
}
