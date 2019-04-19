using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InfraStructure.Data.EntityFramework.Repositories
{
    public class RepositoryEF<T> : IRepository<T> where T : Entity
    {
        protected readonly Contexto _ctx;

        public RepositoryEF(Contexto ctx)
        {
            _ctx = ctx;
        }

        public void Add(T entity)
        {
            _ctx.Set<T>().Add(entity);
            Save();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _ctx.Set<T>().AddRange(entities);
            Save();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Where(predicate);
        }

        public virtual T Get(int? id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _ctx.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            Save();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _ctx.Set<T>().RemoveRange(entities);
            Save();
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            Save();
        }

        private void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
