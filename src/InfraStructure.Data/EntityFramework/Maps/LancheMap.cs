using ApplicationCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraStructure.Data.EntityFramework.Maps
{
    public class LancheMap : IEntityTypeConfiguration<Lanche>
    {
        public void Configure(EntityTypeBuilder<Lanche> builder)
        {
            builder.ToTable("Lanches");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(p => p.Preco)
               .HasColumnType("decimal(5,2)")
               .IsRequired();
        }
    }
}
