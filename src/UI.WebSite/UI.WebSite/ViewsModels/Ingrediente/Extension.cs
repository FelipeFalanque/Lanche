using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.WebSite.ViewsModels.Ingrediente
{
    public static class Extension
    {
        public static IEnumerable<IngredienteVM> ToViewsModels(this IEnumerable<ApplicationCore.Domain.Entities.Ingrediente> ingredientes)
        {
            return ingredientes.Select(p => new IngredienteVM
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco.ToString(),
                DataCadastro = p.DataCadastro.ToString("dd/MM/yyyy")
            });
        }

        public static ApplicationCore.Domain.Entities.Ingrediente ToModel(this IngredienteVM ingredienteVM)
        {
            return new ApplicationCore.Domain.Entities.Ingrediente
            {
                Id = ingredienteVM.Id,
                Nome = ingredienteVM.Nome,
                Preco = Convert.ToDecimal(ingredienteVM.Preco.Replace('.',',')),
                DataCadastro = String.IsNullOrEmpty(ingredienteVM.DataCadastro) ? DateTime.Now : DateTime.Parse(ingredienteVM.DataCadastro)
            };
        }

        public static IngredienteVM ToViewModel(this ApplicationCore.Domain.Entities.Ingrediente ingrediente)
        {
            return new IngredienteVM
            {
                Id = ingrediente.Id,
                Nome = ingrediente.Nome,
                Preco = ingrediente.Preco.ToString(),
                DataCadastro = ingrediente.DataCadastro.ToString("dd/MM/yyyy")
            };
        }
    }
}
