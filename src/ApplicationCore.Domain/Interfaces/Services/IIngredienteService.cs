using ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Domain.Interfaces.Services
{
    public interface IIngredienteService
    {
        Ingrediente Get(int? id);
        IEnumerable<Ingrediente> GetAll();
        IEnumerable<Ingrediente> Find(Expression<Func<Ingrediente, bool>> predicate);

        void Add(Ingrediente entity);
        void AddRange(IEnumerable<Ingrediente> entities);

        void Remove(Ingrediente entity);
        void RemoveRange(IEnumerable<Ingrediente> entities);

        void Update(Ingrediente entity);
    }
}
