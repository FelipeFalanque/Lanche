using ApplicationCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Domain
{
    public class BancoFake
    {
        public static List<Lanche> Lanches { get; set; } = new List<Lanche>();
        public static List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
        public static List<LancheIngrediente> LanchesIngredientes { get; set; } = new List<LancheIngrediente>();

        public static void CarregarBase()
        {
            var Alface = new Ingrediente { Id = 1, Nome = "Alface", Preco = 0.40m };
            var Bacon = new Ingrediente { Id = 2, Nome = "Bacon", Preco = 2.00m };
            var Hamburguer = new Ingrediente { Id = 3, Nome = "Hambúrguer de carne", Preco = 3.00m };
            var Ovo = new Ingrediente { Id = 4, Nome = "Ovo", Preco = 0.80m };
            var Queijo = new Ingrediente { Id = 5, Nome = "Queijo", Preco = 1.50m };

            Ingredientes.AddRange(new List<Ingrediente> {
                Alface,
                Bacon,
                Hamburguer,
                Ovo,
                Queijo
            });
        }
    }
}
