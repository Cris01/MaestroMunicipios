using MaestroMunicipios.Domain.Entities;
using MaestroMunicipios.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaestroMunicipios.Domain.Services
{
    public class CityManagerService
    {
        private readonly IERepository<Department> _Repository;

        public CityManagerService(IERepository<Department> repository )
        {
            this._Repository = repository;
        }
        public async Task<Department> SaveCity(int idDepartent, int codeCity, string nameCity) 
        {
            var departmenstWithCities = await _Repository.GetAsync(null, null, "Cities", true);
            var currentDepartment = departmenstWithCities.FirstOrDefault(d => d.Id == idDepartent);
            var newCity = new City { Code = codeCity, Name = nameCity};
            currentDepartment.Cities.Add(newCity);
            await _Repository.UpdateAsync(currentDepartment).ConfigureAwait(false);
            return await _Repository.GetById(idDepartent).ConfigureAwait(false);
        }
    }
}
