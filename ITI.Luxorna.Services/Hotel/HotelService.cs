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
    public class HotelService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Hotel> HotelRepo;
        private GenericRepository<HotelImage> ImagRepo;
        public HotelService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            HotelRepo = unitOfWork.HotelRepo;
            ImagRepo = unitOfWork.HotelImageRepo;
        }
        public HotelEditViewModel Add(HotelEditViewModel Hotel)
        {
           Hotel _Hotel = HotelRepo.Add(Hotel.toModel());
            unitOfWork.commit();
            if (Hotel.HotelImages != null && Hotel.HotelImages.Count() > 0)
                foreach (var image in Hotel.HotelImages)
                {
                    image.HotelID = _Hotel.ID;
                    ImagRepo.Add(image.toModel());
                }
            unitOfWork.commit();

            return _Hotel.toEditViewModel();
        }
        public HotelEditViewModel Update(HotelEditViewModel Hotel)
        {
            Hotel _Hotel = HotelRepo.Update(Hotel.toModel());
            if (Hotel.HotelImages != null && Hotel.HotelImages.Count() > 0)
            {
                var toAdd = Hotel.HotelImages.Where(i => i.ID == 0);
                foreach (var image in toAdd)
                    ImagRepo.Add(image.toModel());

                var toUpdate = Hotel.HotelImages.Where(i => i.ID > 0);
                foreach (var image in toUpdate)
                    ImagRepo.Update(image.toModel());

                int[] ids = Hotel.HotelImages.Select(x => x.ID).ToArray();
                var toDelete = ImagRepo.GetFilter(i => !ids.Contains(i.ID) && i.HotelID == Hotel.ID);
                foreach (var image in toDelete)
                    ImagRepo.Remove(image);
                //unitOfWork.commit();

            }
            unitOfWork.commit();
            return _Hotel.toEditViewModel();
        }

        public HotelViewModel GetByID(int id)
        {
           Hotel _Hotel = HotelRepo.GetByID(id);
            var hotelViewModel = _Hotel?.toViewModel();

            if (_Hotel != null)
            {
                hotelViewModel.SectionName = _Hotel?.Section.Name;
                hotelViewModel.HotelImages
                    = _Hotel?.HotelImages
                    ?.Select(i => i.toViewModel());

               
            }

            return hotelViewModel;
        }

        public IEnumerable<HotelViewModel> GetAll()
        {

            return HotelRepo.GetAll().Select(i => new HotelViewModel
            {
                ID = i.ID,
                Name = i.Name,
                Description = i.Description,
                Address = i.Address,
                SectionName = i.Section.Name,
                

            }
           ).ToList();
        }
        public IEnumerable<HotelViewModel> GetFilter(string name)
        {
            var Hotels = HotelRepo.GetFilter(a => a.Name == name);
            return Hotels.ToList().Select(i => i.toViewModel());
        }

        public void Remove(int id)
        {

            HotelRepo.Remove(HotelRepo.GetFilter(i => i.ID == id).First()
                );
            unitOfWork.commit();
        }
        public IEnumerable<HotelViewModel> Get(int pageIndex,int pageSize,string name="")
        {
            //int pageSize=3;
            var query =
               HotelRepo.GetAll().Select(i => new HotelViewModel
               {
                   ID = i.ID,
                   Name = i.Name,
                   Description = i.Description,
                   Address = i.Address,
                   SectionName = i.Section.Name,
                   HotelImages=i?.HotelImages?.Select(x => x.toViewModel()),
                   Price =i.Price


               }
           ).ToList();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();
            var  query2 = query.Skip((pageIndex-1) * pageSize).Take(pageSize);
            return query2.ToList();
        }
        public int GetCount()
        {
            var query =
               HotelRepo.GetAll();
            return query.Count();

        }


    }
}
