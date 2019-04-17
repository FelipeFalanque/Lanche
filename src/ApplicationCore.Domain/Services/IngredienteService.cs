using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using ApplicationCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Domain.Services
{
    public class IngredienteService : IIngredienteService, IDisposable
    {
        private readonly IIngredienteRepository _repository;

        public IngredienteService(IIngredienteRepository repository)
        {
            _repository = repository;
        }

        public void Add(Ingrediente entity)
        {
            //TODO: Adicionar regra de negócio

            _repository.Add(entity);
        }

        public void AddRange(IEnumerable<Ingrediente> entities)
        {
            _repository.AddRange(entities);
        }

        public IEnumerable<Ingrediente> Find(Expression<Func<Ingrediente, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public Ingrediente Get(int? id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Ingrediente> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(Ingrediente entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Ingrediente> entities)
        {
            _repository.RemoveRange(entities);
        }

        public void Update(Ingrediente entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
