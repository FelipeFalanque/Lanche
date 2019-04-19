using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using ApplicationCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Domain.Services
{
    public class LancheIngredienteService : ILancheIngredienteService, IDisposable
    {
        private readonly ILancheIngredienteRepository _repository;

        public LancheIngredienteService(ILancheIngredienteRepository repository)
        {
            _repository = repository;
        }

        public void Add(LancheIngrediente entity)
        {
            //TODO: Adicionar regra de negócio

            _repository.Add(entity);
        }

        public void AddRange(IEnumerable<LancheIngrediente> entities)
        {
            _repository.AddRange(entities);
        }

        public IEnumerable<LancheIngrediente> Find(Expression<Func<LancheIngrediente, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public LancheIngrediente Get(int? id)
        {
            if (id == null) return null;

            return _repository.Get(id);
        }

        public IEnumerable<LancheIngrediente> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(LancheIngrediente entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<LancheIngrediente> entities)
        {
            _repository.RemoveRange(entities);
        }

        public void Update(LancheIngrediente entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
