using ApplicationCore.Domain.Entities;
using ApplicationCore.Domain.Helpers.LancheHelper;
using ApplicationCore.Domain.Interfaces.Services;
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

        public DescontosLanches(ILancheService lancheService, IIngredienteService serviceIngrediente)
        {
            _lancheService = lancheService;
            _serviceIngrediente = serviceIngrediente;
        }

        [Fact]
        public void DescontoCadaTresQueijosPagaDois()
        {
            // nesse cenario sera 6 queijos
            Lanche seisQueijos = new Lanche { Nome = "SeisQueijos" };
            seisQueijos.LanchesIngredientes.Add(new LancheIngrediente { IngredienteId = 5, Ingrediente = _serviceIngrediente.Get(5) });
            seisQueijos.CalcularPreco();

            //Id Ingrediente Queijo = 5
            //6 queijos, desconta 2 queijos, da um total de 4 queijos
            var precoDoLanche = _serviceIngrediente.Get(5).Preco * 4;

            Assert.True(precoDoLanche == seisQueijos.Preco);
        }
    }
}
