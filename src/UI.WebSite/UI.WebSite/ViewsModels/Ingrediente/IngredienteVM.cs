using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebSite.ViewsModels.Ingrediente
{
    public class IngredienteVM
    {
        public int Id { get; set; }

        [Display(Name= "Cadastro")]
        public string DataCadastro { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Preço"), Required]
        public string Preco { get; set; }
    }
}
