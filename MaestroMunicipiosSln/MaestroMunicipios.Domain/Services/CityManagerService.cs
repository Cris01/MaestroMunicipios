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

        public CityManagerService(IERepository<Department> repository)
        {
            this._Repository = repository;
        }

        public async Task<Department> GetDepartmentById(int idDepartment)
        {
            var departmenstWithCities = await _Repository.GetAsync(null, null, "Cities", true);
            var department = departmenstWithCities.FirstOrDefault(d => d.Id == idDepartment);
            return department;
        }

        public async Task<List<Department>> GetDepartments()
        {
            var departmenstWithCities = await _Repository.GetAsync(null, null, "Cities", true).ConfigureAwait(false);
            return departmenstWithCities.ToList();
        }

        public async Task<Department> SaveCity(int idDepartment, int codeCity, string nameCity)
        {
            var department = await this.GetDepartmentById(idDepartment).ConfigureAwait(false);
            if (department.Cities.Any(c => c.Name == nameCity))
            {
                return new Department();
            }
            else
            {
                var newCity = new City { Code = codeCity, Name = nameCity };
                department.Cities.Add(newCity);
                await _Repository.UpdateAsync(department).ConfigureAwait(false);
                return await _Repository.GetById(idDepartment).ConfigureAwait(false);
            }
        }

        public async Task<Department> UpdateCity(int idDepartment, int codeCity, string nameCity, int idCity)
        {
            var department = await this.GetDepartmentById(idDepartment).ConfigureAwait(false);
            var citi = department.Cities.FirstOrDefault(c => c.Id == idCity);
            citi.Code = codeCity;
            citi.Name = nameCity;
            await _Repository.UpdateAsync(department).ConfigureAwait(false);
            return await _Repository.GetById(idDepartment).ConfigureAwait(false);
        }

        public async Task<Department> DeleteCity(int idDepartment, int idCity)
        {
            var department = await this.GetDepartmentById(idDepartment).ConfigureAwait(false);
            var citi = department.Cities.FirstOrDefault(c => c.Id == idCity);
            department.Cities.Remove(citi);
            await _Repository.UpdateAsync(department).ConfigureAwait(false);
            return await _Repository.GetById(idDepartment).ConfigureAwait(false);
        }
    }
}
