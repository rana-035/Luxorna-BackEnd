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
    public class ItemService
    {

        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<Item> ItemRepo;
        public ItemService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ItemRepo = unitOfWork.ItemRepo;
        }
        public ItemEditViewModel Add(ItemEditViewModel _ResturantMenuItem)
        {
            Item ResturantMenuItem = ItemRepo.Add(_ResturantMenuItem.ToModel());
            UnitOfWork.commit();
            return ResturantMenuItem.ToEditViewModel();
        }
        public ItemEditViewModel Update(ItemEditViewModel _ResturantMenuItem)
        {
            Item ResturantMenuItem = ItemRepo.Add(_ResturantMenuItem.ToModel());
            UnitOfWork.commit();
            return ResturantMenuItem.ToEditViewModel();
        }
        public ItemViewModel GetByID(int id)
        {
            Item _ResturantMenuItem = ItemRepo.GetByID(id);
            return _ResturantMenuItem.ToViewModel();
        }

        public IEnumerable<ItemViewModel> GetAll()
        {

            return ItemRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<ItemViewModel> GetFilter(string ItemName)
        {
            var ResturantMenuItems = ItemRepo.GetFilter(a => a.Name == ItemName);
            return ResturantMenuItems.ToList().Select(i => i.ToViewModel());
        }

        public void Remove(ItemEditViewModel resturantMenuItem)
        {
            ItemRepo.Remove(resturantMenuItem.ToModel());
            UnitOfWork.commit();
        }
        public IEnumerable<ItemEditViewModel> Get(int pageIndex, int pageSize, int ResturantID)
        {
            //int pageSize = 2;
            var query =
               ItemRepo.GetFilter(a => a.RestrantID == ResturantID).ToList()
                    .Select(i => i.ToEditViewModel());
            var query2 = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query2.ToList();
        }


        public PagingViewModel Get(int id = 0, string name = "", int sizeId = 0, int restuarantId = 0, int pageIndex = 1, int pageSize = 3)
        {
            var query = ItemRepo.GetAll();
            if (id > 0)
                query = query.Where(i => i.ID == id);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name.Contains(name));
            if (sizeId > 0)
                query = query.Where(i => i.ItemSizes.Any(x => x.SizeID == sizeId));
            if (restuarantId > 0)
                query = query.Where(i => i.RestrantID == restuarantId);

            int records = query.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            query = query.OrderBy(i => i.ID).Skip(excludedRows).Take(pageSize).ToList();
            var data = query.Select(i => i.ToViewModel()).ToList();  
            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = data, Records = records, Pages = pages };
        }
        public int GetCount()
        {
            var query =
               ItemRepo.GetAll();
            return query.Count();

        }
    }
}
