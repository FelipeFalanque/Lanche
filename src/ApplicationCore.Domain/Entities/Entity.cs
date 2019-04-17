using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
