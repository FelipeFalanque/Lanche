using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.Entities
{
    public class LancheIngrediente : Entity
    {
        public int IdLanche { get; set; }
        public int IdIngrediente { get; set; }
        public int QtdIngrediente { get; set; }
    }
}
