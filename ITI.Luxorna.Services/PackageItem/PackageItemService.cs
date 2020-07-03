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
    public class PackageItemService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<PackageItem> PackageItemRepo;
        public PackageItemService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            PackageItemRepo = unitOfWork.PackageItemRepo;
        }
        public PackageItemEditViewModel Add(PackageItemEditViewModel _PackageItem)
        {
            PackageItem PackageItem = PackageItemRepo.Add(_PackageItem.toModel());
            UnitOfWork.commit();
            return PackageItem.toEditViewModel();
        }
        public PackageItemEditViewModel Update(PackageItemEditViewModel _PackageItem)
        {
            PackageItem PackageItem = PackageItemRepo.Add(_PackageItem.toModel());
            UnitOfWork.commit();
            return PackageItem.toEditViewModel();
        }
        public PackageItemViewModel GetByID(int id)
        {
            PackageItem _PackageItem = PackageItemRepo.GetByID(id);
            return _PackageItem.toViewModel();
        }

        public IEnumerable<PackageItemViewModel> GetAll()
        {

            return PackageItemRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        //public IEnumerable<PackageItemViewModel> GetFilter(string ItemName)
        //{
        //    var PackageItems = PackageItemRepo.GetFilter(a => a.ItemName == ItemName);
        //    return PackageItems.ToList().Select(i => i.toViewModel());
        //}

        public void Remove(int id)
        {
           PackageItemRepo.Remove( PackageItemRepo.GetFilter(i => i.ID == id).First()
             );
            UnitOfWork.commit();
        }
    }
}
