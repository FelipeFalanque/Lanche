using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace UnitTests.Domain
{
    public class LancheRepositoryTest : ILancheRepository
    {
        public void Add(Lanche entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Lanche> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lanche> Find(Expression<Func<Lanche, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Lanche Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lanche> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lanche> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public void Remove(Lanche entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Lanche> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Lanche entity)
        {
            throw new NotImplementedException();
        }
    }
}
