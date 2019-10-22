using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaestroMunicipios.Domain.IRepositories
{
    public interface IERepository<E> where E : Domain.Entities.DomainEntity
    {
        Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>> filter = null,
               Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
               string includeProperties = "", bool isTracking = false);

        Task<E> GetById(object id);
        Task<E> AddAsync(E entity);
        Task UpdateAsync(E entity);
        Task DeleteAsync(E entity);
        void Dispose();
    }
}
