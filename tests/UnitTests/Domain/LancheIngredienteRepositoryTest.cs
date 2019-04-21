using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace UnitTests.Domain
{
    public class LancheIngredienteRepositoryTest : ILancheIngredienteRepository
    {
        public void Add(LancheIngrediente entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LancheIngrediente> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LancheIngrediente> Find(Expression<Func<LancheIngrediente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LancheIngrediente Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LancheIngrediente> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(LancheIngrediente entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LancheIngrediente> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(LancheIngrediente entity)
        {
            throw new NotImplementedException();
        }
    }
}
