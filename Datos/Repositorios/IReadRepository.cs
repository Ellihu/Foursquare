using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Datos.Repositorios
{
    public interface IReadRepository<T>
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        public IEnumerable<T> Get(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        T GetFirst(Expression<Func<T, bool>> predicate);
        T GetFirst(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        T GetLast(Expression<Func<T, object>> predicate);
        T GetById(int id);
        T GetById(Guid id);
        int GetNextId(Expression<Func<T, object>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        int Count(Expression<Func<T, bool>> predicate);
    }


}
