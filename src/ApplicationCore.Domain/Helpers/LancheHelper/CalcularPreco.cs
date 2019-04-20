using ApplicationCore.Domain.Entities;
using System;
using System.Linq;

namespace ApplicationCore.Domain.Helpers.LancheHelper
{
    public static class CalculaPreco
    {
        public static void CalcularPreco(this Lanche lanche)
        {
            decimal preco = 0.0m;

            //1-Alface
            //2-Bacon
            //3-Hambúrguer de carne
            //4-Ovo
            //5-Queijo

            var alface = lanche.LanchesIngredientes.FirstOrDefault(li => li.IngredienteId == 1);
            var bacon = lanche.LanchesIngredientes.FirstOrDefault(li => li.IngredienteId == 2);
            var hamburge = lanche.LanchesIngredientes.FirstOrDefault(li => li.IngredienteId == 3);
            var ovo = lanche.LanchesIngredientes.FirstOrDefault(li => li.IngredienteId == 4);
            var queijo = lanche.LanchesIngredientes.FirstOrDefault(li => li.IngredienteId == 5);

            preco += alface != null ? (alface.QtdIngrediente * alface.Ingrediente.Preco) : 0.0m;
            preco += bacon != null ? (bacon.QtdIngrediente * bacon.Ingrediente.Preco) : 0.0m;
            preco += hamburge != null ? (hamburge.QtdIngrediente * hamburge.Ingrediente.Preco) : 0.0m;
            preco += ovo != null ? (ovo.QtdIngrediente * ovo.Ingrediente.Preco) : 0.0m;
            preco += queijo != null ? (queijo.QtdIngrediente * queijo.Ingrediente.Preco) : 0.0m;

            //Nesse Momento temos o preco sem desconto
            var precoSemDesconto = preco;

            //Se o lanche tem alface e não tem bacon, ganha 10 % de desconto.
            if (alface != null && bacon == null) {
                preco -= ((preco / 100) * 10);
            }

            //Muita carne
            //A cada 3 porções de carne o cliente só paga 2.Se o lanche tiver 6 porções, ocliente pagará 4.Assim por diante
            if (hamburge != null) {
                if (hamburge.QtdIngrediente >= 3) {
                    // para cada conjunto de 3 humburges ganha um desconto no valor de 1 humburge
                    double r = (hamburge.QtdIngrediente / 3);
                    int totalDescontos = Convert.ToInt32(Math.Floor(r));
                    preco -= totalDescontos * hamburge.Ingrediente.Preco;
                }
            }

            //Muito queijo
            //A cada 3 porções de queijo o cliente só paga 2.Se o lanche tiver 6 porções, ocliente pagará 4.Assim por diante
            if (queijo != null)
            {
                if (queijo.QtdIngrediente >= 3)
                {
                    // para cada conjunto de 3 queijos ganha um desconto no valor de 1 queijo
                    double r = (queijo.QtdIngrediente / 3);
                    int totalDescontos = Convert.ToInt32(Math.Floor(r));
                    preco -= totalDescontos * queijo.Ingrediente.Preco;
                }
            }

            lanche.Preco = preco;
        }
    }
}
