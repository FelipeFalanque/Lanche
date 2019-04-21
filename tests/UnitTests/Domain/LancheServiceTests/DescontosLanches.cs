using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Helpers.LancheHelper;
using ApplicationCore.Domain.Interfaces.Services;
using ApplicationCore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTests.Domain.LancheServiceTests
{
    public class DescontosLanches
    {
        private readonly ILancheService _lancheService;
        private readonly IIngredienteService _serviceIngrediente;

        public DescontosLanches()
        {
            _lancheService = new LancheService(new LancheRepositoryTest(),new LancheIngredienteRepositoryTest());
            _serviceIngrediente = new IngredienteService(new IngredienteRepositoryTest());

            if (!BancoFake.Ingredientes.Any())
            {
                BancoFake.CarregarBase();
            }
        }

        [Fact]
        public void DescontoCadaTresQueijosPagaDois()
        {
            // Lanche
            Lanche seisQueijos = new Lanche { Id = 1, Nome = "SeisQueijos" };
            // Ingrediente
            Ingrediente queijo = _serviceIngrediente.Get(5);
            // Lanche Ingrediente
            LancheIngrediente li = new LancheIngrediente {
                Id = 1,
                Lanche = seisQueijos,
                LancheId = 1,
                Ingrediente = queijo,
                IngredienteId = queijo.Id,
                QtdIngrediente = 6
            };
            // Add Lanche Ingrediente
            seisQueijos.LanchesIngredientes.Add(li);
            // Calcula preço do lanche
            seisQueijos.CalcularPreco();

            //6 queijos, desconta 2 queijos, da um total de 4 queijos
            var precoFinalDoLanche = queijo.Preco * 4;

            Assert.True(precoFinalDoLanche == seisQueijos.Preco);
        }

        [Fact]
        public void DescontoDeDezPorCentoCasoTenhaAlface()
        {
            // Lanche
            Lanche xOvo = new Lanche { Id = 1, Nome = "xOvo" };
            // Ingredientes
            Ingrediente ovo = _serviceIngrediente.Get(4);
            Ingrediente alface = _serviceIngrediente.Get(1);
            // União Lanche Ingrediente
            LancheIngrediente liOvo = new LancheIngrediente
            {
                Id = 1,
                Lanche = xOvo,
                LancheId = 1,
                Ingrediente = ovo,
                IngredienteId = ovo.Id,
                QtdIngrediente = 10
            };
            LancheIngrediente liAlface = new LancheIngrediente
            {
                Id = 1,
                Lanche = xOvo,
                LancheId = 1,
                Ingrediente = alface,
                IngredienteId = alface.Id,
                QtdIngrediente = 1
            };
            // União Lanche Ingrediente
            xOvo.LanchesIngredientes.Add(liOvo);
            xOvo.LanchesIngredientes.Add(liAlface);
            // Calcula Preco do lanche.
            xOvo.CalcularPreco();

            var precoDoLancheSemDesconto = (ovo.Preco * 10) + alface.Preco;
            var precoDoLancheComDesconto = precoDoLancheSemDesconto - ((precoDoLancheSemDesconto / 100) * 10);

            Assert.True(precoDoLancheComDesconto == xOvo.Preco);
        }
    }
}
