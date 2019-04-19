using ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Domain.Interfaces.Services
{
    public interface ILancheIngredienteService
    {
        LancheIngrediente Get(int? id);
        IEnumerable<LancheIngrediente> GetAll();
        IEnumerable<LancheIngrediente> Find(Expression<Func<LancheIngrediente, bool>> predicate);

        void Add(LancheIngrediente entity);
        void AddRange(IEnumerable<LancheIngrediente> entities);

        void Remove(LancheIngrediente entity);
        void RemoveRange(IEnumerable<LancheIngrediente> entities);

        void Update(LancheIngrediente entity);
    }
}
