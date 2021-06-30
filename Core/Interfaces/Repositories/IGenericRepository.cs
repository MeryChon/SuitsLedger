using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Base;
using Core.Interfaces.Specifications;

namespace Core.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpecification(ISpecification<T> specification);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);

        Task<int> CountAsync(ISpecification<T> specification);

        Task<T> Create(T item);

        Task<T> Update(T item);

        void Delete(int id);

    }
}