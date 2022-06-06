using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Datos.Repositorios
{
    public abstract class GenericRepository<T> : ICreateRepository<T>, IUpdateRepository<T>, IReadRepository<T>, IRemoveRepository<T> where T : class
    {
        protected ApplicationDbContext context { get; }

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }



        #region Agregar
        public virtual T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual void Add(IEnumerable<T> t)
        {
            context.AddRange(t);
        }
        #endregion

        #region Update

        public virtual T Update(T entity)
        {
            return context.Update(entity).Entity;
        }


        public void Update(IEnumerable<T> entity)
        {
            context.UpdateRange(entity);
        }
        #endregion

        #region buscar

        public virtual IEnumerable<T> Get()
        {
            return context.Set<T>();//.ToList();
        }
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
               .Where(predicate);
            //.ToList();
        }
        public IEnumerable<T> Get(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            var query = context.Set<T>().AsQueryable();
            query = include(query);

            return query;//.ToList();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            var query = context.Set<T>().AsQueryable();
            query = include(query);
            query = query.Where(predicate);

            return query;//.ToList();
        }
        public virtual T GetFirst(Expression<Func<T, bool>> option)
        {
            return context.Set<T>().FirstOrDefault(option);
        }
        public T GetFirst(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            var query = context.Set<T>().AsQueryable();
            query = include(query);
            query = query.Where(predicate);

            return query.FirstOrDefault();
        }
        public virtual T GetById(Guid id)
        {
            return context.Find<T>(id);
        }
        public virtual T GetById(int id)
        {
            return context.Find<T>(id);
        }
        public int GetNextId(Expression<Func<T, object>> option)
        {

            string keyPropertyName = GetPrimaryKey();
            //Type keyPropertyType = typeof(T)
            //                            .GetProperty(keyPropertyName)
            //                            .PropertyType;
            var lastId = context.Set<T>().OrderByDescending(option).FirstOrDefault();
            int id = lastId != null ? (int)lastId.GetType().GetProperty(keyPropertyName).GetValue(lastId, null) : 0;
            return id += 1;
        }
        public T GetLast(Expression<Func<T, object>> option)
        {
            return context.Set<T>().OrderByDescending(option).FirstOrDefault();
        }
        public bool Any(Expression<Func<T, bool>> option)
        {
            return context.Set<T>().Any(option);
        }
        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Count(predicate);

        }

        #endregion

        #region Remove

        public virtual void Remove(T t)
        {
            context.Remove(t);
        }
        public virtual void Remove(IEnumerable<T> t)
        {
            context.RemoveRange(t);
        }
        #endregion
        private string GetPrimaryKey()
        {
            return typeof(T).GetProperties()
                    .Where(
                        x => x.CustomAttributes
                        .Where(y => y.AttributeType.Name == "KeyAttribute")
                        .Count() > 0
                     ).FirstOrDefault().Name;
        }
        private void SaveChanges()
        {
            context.SaveChanges();
        }


    }


}

