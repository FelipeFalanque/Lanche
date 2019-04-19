using ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Domain.Interfaces.Services
{
    public interface ILancheService
    {
        Lanche Get(int? id);
        IEnumerable<Lanche> GetAll();
        IEnumerable<Lanche> GetAllEager();
        IEnumerable<Lanche> Find(Expression<Func<Lanche, bool>> predicate);

        void Add(Lanche entity);
        void AddRange(IEnumerable<Lanche> entities);

        void Remove(Lanche entity);
        void RemoveRange(IEnumerable<Lanche> entities);

        void Update(Lanche entity);
    }
}
