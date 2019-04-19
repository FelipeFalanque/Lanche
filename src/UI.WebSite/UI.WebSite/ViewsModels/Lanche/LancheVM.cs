using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebSite.ViewsModels.Lanche
{
    public class LancheVM
    {
        public int Id { get; set; }

        [Display(Name = "Cadastro")]
        public string DataCadastro { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Preço"), Required]
        public string Preco { get; set; }

        public ICollection<IngredienteLancheVM> Ingredientes { get; set; }

        public LancheVM()
        {
            Ingredientes = new List<IngredienteLancheVM>();
        }
    }
}
