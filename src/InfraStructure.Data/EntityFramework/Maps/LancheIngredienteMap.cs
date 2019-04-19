using ApplicationCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraStructure.Data.EntityFramework.Maps
{
    public class LancheIngredienteMap : IEntityTypeConfiguration<LancheIngrediente>
    {
        public void Configure(EntityTypeBuilder<LancheIngrediente> lancheingrediente)
        {
            lancheingrediente.ToTable("LanchesIngredientes");

            // Chave primaria cliente
            lancheingrediente.HasKey(li => li.Id);

            // n para n clientes
            lancheingrediente
                .HasOne(li => li.Lanche)
                .WithMany(l => l.LanchesIngredientes)
                .HasForeignKey(li => li.LancheId)
                .OnDelete(DeleteBehavior.Restrict); /* não deletar em cascata. */

            // n para n profissoes
            lancheingrediente
                .HasOne(li => li.Ingrediente)
                .WithMany(i => i.LanchesIngredientes)
                .HasForeignKey(li => li.IngredienteId)
                .OnDelete(DeleteBehavior.Restrict); /* não deletar em cascata. */
        }
    }
}