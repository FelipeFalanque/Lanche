using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Data.EntityFramework.Repositories
{
    public class LancheRepository : RepositoryEF<Lanche>, ILancheRepository
    {
        public LancheRepository(Contexto ctx) : base(ctx)
        { }

        public override Lanche Get(int? id)
        {
            return _ctx.Lanches
            .Include(l => l.LanchesIngredientes)
            .ThenInclude(li => li.Ingrediente).FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Lanche> GetAllEager()
        {
            return _ctx.Lanches
                .Include(l => l.LanchesIngredientes)
                .ThenInclude(li => li.Ingrediente);
        }
    }
}
