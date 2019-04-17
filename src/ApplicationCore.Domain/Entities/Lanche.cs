using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.Entities
{
    public class Lanche : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
