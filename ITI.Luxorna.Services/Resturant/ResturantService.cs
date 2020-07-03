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
    public class ResturantService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenericRepository<Resturant> ResturantRepo;
        private GenericRepository<ResturantImage> ImagRepo;
        private GenericRepository<Item> ItemRepo;
        private GenericRepository<ItemSize> ItemSizeRepo;
        public ResturantService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ResturantRepo = unitOfWork.ResturantRepo;
            ImagRepo = unitOfWork.ResturantImageRepo;
            ItemRepo = unitOfWork.ItemRepo;
            ItemSizeRepo = unitOfWork.ItemSizeRepo;
        }
        public ResturantEditViewModel Add(ResturantEditViewModel Resturant)
        {
            Resturant _Resturant = ResturantRepo.Add(Resturant.ToModel());
            UnitOfWork.commit();
            if (Resturant.ResturantImages != null && Resturant.ResturantImages.Count() > 0)
                foreach (var image in Resturant.ResturantImages)
                {
                    image.ResturantID = _Resturant.ID;
                    ImagRepo.Add(image.ToModel());
                }

            if (Resturant.Items != null && Resturant.Items.Count() > 0)
            {
                foreach (var item in Resturant.Items)
                {
                    item.ResturantID = _Resturant.ID;
                    Item Inserted = ItemRepo.Add(item.ToModel());
                    UnitOfWork.commit();
                    if (item.ItemDetail != null && item.ItemDetail.Count() > 0)
                    {
                        foreach (var inner in item.ItemDetail)
                        {
                            inner.ItemID = Inserted.ID;
                            ItemSizeRepo.Add(inner.ToModel());
                        }
                    }
                }
            }
            UnitOfWork.commit();
            return _Resturant.ToEditViewModel();
        }

        public ResturantEditViewModel Update(ResturantEditViewModel Resturant)
        {
            Resturant _Resturant = ResturantRepo.Update(Resturant.ToModel());
            if (Resturant.ResturantImages != null && Resturant.ResturantImages.Count() > 0)
            {
                var toAdd = Resturant.ResturantImages.Where(i => i.ID == 0);
                foreach (var image in toAdd)
                    ImagRepo.Add(image.ToModel());

                var toUpdate = Resturant.ResturantImages.Where(i => i.ID > 0);
                foreach (var image in toUpdate)
                    ImagRepo.Update(image.ToModel());

                int[] ids = Resturant.ResturantImages.Select(x => x.ID).ToArray();
                var toDelete = ImagRepo.GetFilter(i => !ids.Contains(i.ID) && i.ResturantID == Resturant.ID);
                foreach (var image in toDelete)
                    ImagRepo.Remove(image);
             

            }
            if (Resturant.Items != null && Resturant.Items.Count() > 0)
            {
                var toAdd = Resturant.Items.Where(i => i.ID == 0);
                foreach (var item in toAdd)
                {
                    var inserted = ItemRepo.Add(item.ToModel());
                    UnitOfWork.commit();
                    if (item.ItemDetail != null && item.ItemDetail.Count() > 0)
                    {
                        foreach (var innerItem in item.ItemDetail)
                        {
                            innerItem.ItemID = inserted.ID;
                            ItemSizeRepo.Add(innerItem.ToModel());
                        }
                    }
                }


                var toUpdate = Resturant.Items.Where(i => i.ID > 0);
                foreach (var itemToUpdate in toUpdate)
                {
                    ItemRepo.Update(itemToUpdate.ToModel());

                    var itemDetailsToAdd
                        = itemToUpdate.ItemDetail.Where(i => i.ID == 0);
                    foreach (var detail in itemDetailsToAdd)
                        ItemSizeRepo.Add(detail.ToModel());


                    var itemsToBeUpdated
                        = itemToUpdate.ItemDetail.Where(i => i.ID > 0);

                    foreach (var detail in itemsToBeUpdated)
                    {
                        ItemSizeRepo.Update(detail.ToModel());
                    }

                    int[] ids = itemToUpdate.ItemDetail.Select
                        (x => x.ID).ToArray();
                    var itemsToDeleted
                        = ItemSizeRepo
                        .GetFilter(i => !ids.Contains(i.ID) && i.ItemID == itemToUpdate.ID);

                    foreach (var detail in itemsToDeleted)
                        ItemSizeRepo.Remove(detail);

                }


                var idsOfItems = Resturant.Items.Select(X => X.ID)
                    .ToArray();

                var DeletedItems
                    = ItemRepo.GetFilter
                    (i => !idsOfItems.Contains(i.ID) && i.RestrantID == Resturant.ID);

                foreach (var item in DeletedItems)
                    ItemRepo.Remove(item);
             

            }
            UnitOfWork.commit();
            return _Resturant.ToEditViewModel();
        }
        public ResturantViewModel GetByID(int id)
        {
            Resturant _Resturant = ResturantRepo.GetByID(id);
            var restuarantViewModel = _Resturant?.toViewModel();

            if (_Resturant != null)
            {
                restuarantViewModel.SectionName = _Resturant?.Section.Name;
                restuarantViewModel.ResturantImages
                    = _Resturant?.ResturantImages
                    ?.Select(i => i.toViewModel());

                restuarantViewModel.Items
                    = _Resturant?.Items
                    ?.Select(i => i.ToViewModel());
            }

            return restuarantViewModel;
        }


        public IEnumerable<ResturantViewModel> GetAll()
        {

            return ResturantRepo.GetAll().Select(i => new ResturantViewModel
            {
                ID = i.ID,
                Name = i.Name,
                Description = i.Description,
                Address = i.Address,
                SectionName = i.Section.Name

            }
            ).ToList();
        }

        public IEnumerable<ResturantViewModel> GetFilter(string name)
        {
            var Resturants = ResturantRepo.GetFilter(a => a.Name == name);
            return Resturants.ToList().Select(i => i.toViewModel());
        }

        public ResturantEditViewModel GetID(int id)
        {
            Resturant _Resturant = ResturantRepo.GetByID(id);
            var restuarantEditViewModel = _Resturant?.ToEditViewModel();

            if (_Resturant != null)
            {
                restuarantEditViewModel.SectionName = _Resturant?.Section.Name;
                restuarantEditViewModel.ResturantImages
                    = _Resturant?.ResturantImages
                    ?.Select(i => i.ToEditViewModel());

                restuarantEditViewModel.Items
                    = _Resturant?.Items
                    ?.Select(i => i.ToEditViewModel());
            }

            return restuarantEditViewModel;
        }


        public void Remove(int id)
        {

            ResturantRepo.Remove(ResturantRepo.GetFilter(i=>i.ID==id).First()
                );
            UnitOfWork.commit();
        }
        public IEnumerable<ResturantViewModel> Get(int pageIndex,int pageSize,string name="")
        {
            //int pageSize = 3;
           var query =
               ResturantRepo.GetAll().Select(i => new ResturantViewModel
               {
                   ID = i.ID,
                   Name = i.Name,
                   Description = i.Description,
                   Address = i.Address,
                   SectionName = i.Section.Name,
                   ResturantImages = i?.ResturantImages?.Select(x => x.toViewModel()),
                   Items = i?.Items
                    ?.Select(x => x.ToViewModel())


        }
           ).ToList();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();
            var query2 = query.Skip((pageIndex-1) * pageSize).Take(pageSize);
            return query2.ToList();
        }
        public int GetCount()
        {
            var query =
               ResturantRepo.GetAll();
            return query.Count();
           
        }
    }
}