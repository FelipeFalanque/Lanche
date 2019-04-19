using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Domain.Entities;

namespace UI.WebSite.ViewsModels.Lanche
{
    public static class Extension
    {
        public static IEnumerable<LancheVM> ToViewsModels(this IEnumerable<ApplicationCore.Domain.Entities.Lanche> lanches)
        {
            return lanches.Select(p => new LancheVM
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco.ToString(),
                DataCadastro = p.DataCadastro.ToString("dd/MM/yyyy"),
                Ingredientes = Ingredientes(p.LanchesIngredientes).ToList()
            });
        }

        public static ApplicationCore.Domain.Entities.Lanche ToModel(this LancheVM lancheVM)
        {
            return new ApplicationCore.Domain.Entities.Lanche
            {
                Id = lancheVM.Id,
                Nome = lancheVM.Nome,
                Preco = Convert.ToDecimal(lancheVM.Preco.Replace('.', ',')),
                DataCadastro = String.IsNullOrEmpty(lancheVM.DataCadastro) ? DateTime.Now : DateTime.Parse(lancheVM.DataCadastro),
                LanchesIngredientes = LanchesIngredientes(lancheVM.Id, lancheVM.Ingredientes).ToList()
            };
        }

        public static LancheVM ToViewModel(this ApplicationCore.Domain.Entities.Lanche lanche)
        {
            return new LancheVM
            {
                Id = lanche.Id,
                Nome = lanche.Nome,
                Preco = lanche.Preco.ToString(),
                DataCadastro = lanche.DataCadastro.ToString("dd/MM/yyyy"),
                Ingredientes = Ingredientes(lanche.LanchesIngredientes).ToList()
            };
        }

        private static IEnumerable<IngredienteLancheVM> Ingredientes(IEnumerable<ApplicationCore.Domain.Entities.LancheIngrediente> lanchesIngredientes)
        {
            return lanchesIngredientes.Select(i => new IngredienteLancheVM
            {
                IdIngrediente = i.IngredienteId,
                NomeIngrediente = i.Ingrediente.Nome,
                QtdIngrediente = i.QtdIngrediente
            });
        }

        private static IEnumerable<LancheIngrediente> LanchesIngredientes(int lancheId, ICollection<IngredienteLancheVM> ingredientes)
        {
            return ingredientes.Select(li => new LancheIngrediente
            {
                LancheId = lancheId,
                IngredienteId = li.IdIngrediente,
                QtdIngrediente = li.QtdIngrediente,
            });
        }
    }
}
