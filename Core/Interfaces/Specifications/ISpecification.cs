using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities.Base;

namespace Core.Interfaces.Specifications
{
    public interface ISpecification<T> where T : Entity
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDesc { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }

    }
}