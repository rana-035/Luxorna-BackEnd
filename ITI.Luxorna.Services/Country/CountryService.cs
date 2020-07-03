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
    public class CountryService
    {
        public UnitOfWork unitOfWork { get; set; }
        private GenericRepository<Country> CountryRepo;
        public CountryService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            CountryRepo = unitOfWork.CountryRepo;
        }
        public CountryEditViewModel Add(CountryEditViewModel country)
        {
            Country _country = CountryRepo.Add(country.toModel());
            unitOfWork.commit();
            return _country.toEditViewModel();
        }
        public CountryEditViewModel Update(CountryEditViewModel country)
        {
            Country _country = CountryRepo.Update(country.toModel());
            unitOfWork.commit();
            return _country.toEditViewModel();
        }

        public CountryViewModel GetByID(int id)
        {
            Country Country = CountryRepo.GetByID(id);
            return Country.toViewModel();
        }

        public IEnumerable<CountryViewModel> GetAll()
        {

            return CountryRepo.GetAll().ToList().Select(i => i.toViewModel());
        }
        public IEnumerable<CountryViewModel> GetFilter(string Name)
        {
            var Departments = CountryRepo.GetFilter(a => a.Name == Name);
            return Departments.ToList().Select(i => i.toViewModel());
        }

        public void Remove(CountryEditViewModel Country)
        {
            CountryRepo.Remove(Country.toModel());
            unitOfWork.commit();
        }

    }
}
