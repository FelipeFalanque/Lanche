using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfraStructure.Data.EntityFramework.Repositories
{
    public class IngredienteRepository : RepositoryEF<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(Contexto ctx) : base(ctx)
        { }
    }
}
