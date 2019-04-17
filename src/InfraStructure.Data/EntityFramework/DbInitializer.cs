using ApplicationCore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace InfraStructure.Data.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initialize(Contexto context)
        {
            if (context.Ingredientes.Any())
            {
                return;
            }

            var ingredientes = new List<Ingrediente> {
                new Ingrediente{ Nome = "Alface", Preco = 0.40m },
                new Ingrediente{ Nome = "Bacon", Preco = 2.00m },
                new Ingrediente{ Nome = "Hambúrguer de carne", Preco = 3.00m },
                new Ingrediente{ Nome = "Ovo", Preco = 0.80m },
                new Ingrediente{ Nome = "Queijo", Preco = 1.50m }
            };

            context.Ingredientes.AddRange(ingredientes);

            context.SaveChanges();
        }
    }
}
