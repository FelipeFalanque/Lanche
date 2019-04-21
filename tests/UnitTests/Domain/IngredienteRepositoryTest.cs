using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UnitTests.Domain
{
    public class IngredienteRepositoryTest : IIngredienteRepository
    {
        public void Add(Ingrediente entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Ingrediente> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingrediente> Find(Expression<Func<Ingrediente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ingrediente Get(int? id)
        {
            return BancoFake.Ingredientes.First(i => i.Id == id);
        }

        public IEnumerable<Ingrediente> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Ingrediente entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Ingrediente> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Ingrediente entity)
        {
            throw new NotImplementedException();
        }
    }
}
