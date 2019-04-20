using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Helpers.LancheHelper;
using ApplicationCore.Domain.Interfaces.Repositories;
using ApplicationCore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Domain.Services
{
    public class LancheService : ILancheService, IDisposable
    {
        private readonly ILancheRepository _repoLanche;
        private readonly ILancheIngredienteRepository _repoLancheIngrediente;

        public LancheService(ILancheRepository repoLanche, ILancheIngredienteRepository repoLancheIngrediente)
        {
            _repoLanche = repoLanche;
            _repoLancheIngrediente = repoLancheIngrediente;
        }

        public void Add(Lanche entity)
        {
            //TODO: Adicionar regra de negócio

            _repoLanche.Add(entity);
        }

        public void AddRange(IEnumerable<Lanche> entities)
        {
            _repoLanche.AddRange(entities);
        }

        public IEnumerable<Lanche> Find(Expression<Func<Lanche, bool>> predicate)
        {
            return _repoLanche.Find(predicate);
        }

        public Lanche Get(int? id)
        {
            if (id == null) return null;

            return _repoLanche.Get(id);
        }

        public IEnumerable<Lanche> GetAll()
        {
            return _repoLanche.GetAll();
        }

        public IEnumerable<Lanche> GetAllEager()
        {
            return _repoLanche.GetAllEager();
        }

        public void Remove(Lanche entity)
        {
            _repoLanche.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Lanche> entities)
        {
            _repoLanche.RemoveRange(entities);
        }

        public void Update(Lanche entity)
        {
            //Para gatantir vou aparga as associaçoes e criar novamente

            // associações desse lanche
            var associacoes = _repoLancheIngrediente.Find(li => li.LancheId == entity.Id);
            _repoLancheIngrediente.RemoveRange(associacoes);

            // refaz associações
            var novas_associacoes = entity.LanchesIngredientes;
            _repoLancheIngrediente.AddRange(novas_associacoes);

            // Calcula Preço
            entity.CalcularPreco();

            _repoLanche.Update(entity);
        }

        public void Dispose()
        {
            _repoLanche.Dispose();
        }
    }
}