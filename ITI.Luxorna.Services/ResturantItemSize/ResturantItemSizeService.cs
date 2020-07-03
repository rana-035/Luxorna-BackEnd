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
    public class ItemSizeService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<ItemSize> ItemSizeRepo;
        public ItemSizeService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ItemSizeRepo = unitOfWork.ItemSizeRepo;
        }
        public ItemSizeEditViewModel Add(ItemSizeEditViewModel _ItemSize)
        {
            ItemSize ItemSize = ItemSizeRepo.Add(_ItemSize.ToModel());
            UnitOfWork.commit();
            return ItemSize.ToEditViewModel();
        }
        public ItemSizeEditViewModel Update(ItemSizeEditViewModel _ItemSize)
        {
            ItemSize ItemSize =ItemSizeRepo.Add(_ItemSize.ToModel());
            UnitOfWork.commit();
            return ItemSize.ToEditViewModel();
        }
        public ItemSizeViewModel GetByID(int id)
        {
            ItemSize _ItemSize = ItemSizeRepo.GetByID(id);
            return _ItemSize.ToViewModel();
        }

        public IEnumerable<ItemSizeViewModel> GetAll()
        {

            return ItemSizeRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<ItemSizeViewModel> GetFilter(int id)
        {
            var ResturantItemSizes = ItemSizeRepo.GetFilter(a => a.ID== id);
            return ResturantItemSizes.ToList().Select(i => i.ToViewModel());
        }

        public void Remove(ItemSizeEditViewModel ItemSize)
        {
            ItemSizeRepo.Remove(ItemSize.ToModel());
            UnitOfWork.commit();
        }
    }
}
