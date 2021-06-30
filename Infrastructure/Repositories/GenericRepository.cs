using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities.Base;
using Core.Interfaces.Repositories;
using Core.Interfaces.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly SuitLedgerContext _context;

        public GenericRepository(SuitLedgerContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        public async Task<T> Create(T item)
        {
            var createdItem = await _context.AddAsync<T>(item);
            await _context.SaveChangesAsync();
            return createdItem.Entity;
        }

        public async Task<T> Update(T item)
        {
            var currentItem = _context.FindAsync<T>(item.Id);
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            foreach (PropertyInfo propInfo in propertyInfos)
            {
                var propValue = propInfo.GetValue(item);
                if (propValue != null && !IsNotMappedProperty(propInfo))
                {
                    propInfo.SetValue(currentItem.Result, propValue);
                }
            }

            await _context.SaveChangesAsync();
            return await _context.FindAsync<T>(item.Id); // TODO: There should be a way of wrapping item in Task
        }

        private bool IsNotMappedProperty(PropertyInfo propertyInfo)
        {
            var customAttributes = propertyInfo.GetCustomAttributes(typeof(NotMappedAttribute), true);
            return customAttributes.Count() >= 1;
        }

        public void Delete(int id)
        {
            T item = _context.Find<T>(id);
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }
    }
}