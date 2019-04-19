using ApplicationCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Data.EntityFramework
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { }

        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<LancheIngrediente> LanchesIngredientes { get; set; }

        //fluente API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configurações de Tabelas
            builder.ApplyConfiguration(new Maps.LancheMap());
            builder.ApplyConfiguration(new Maps.IngredienteMap());
            builder.ApplyConfiguration(new Maps.LancheIngredienteMap());
        }
    }
}
