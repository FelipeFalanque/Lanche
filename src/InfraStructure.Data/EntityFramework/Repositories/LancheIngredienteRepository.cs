using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;

namespace InfraStructure.Data.EntityFramework.Repositories
{
    public class LancheIngredienteRepository : RepositoryEF<LancheIngrediente>, ILancheIngredienteRepository
    {
        public LancheIngredienteRepository(Contexto ctx) : base(ctx)
        { }
    }
}
