using System.Linq;
using Core.Entities.Base;
using Core.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SpecificationEvaluator<T> where T : Entity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> iQueriable, ISpecification<T> specification)
        {
            var query = iQueriable;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.Includes != null)
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}