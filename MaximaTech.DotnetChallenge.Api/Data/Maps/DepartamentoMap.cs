using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaximaTech.DotnetChallenge.Api.Data.Maps
{
    public class DepartamentoMap : BaseMap<Departamento>, IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("DEPARTAMENTOS");

            ConfigureBaseModel(builder);

            #region DESCRICAO

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasColumnType("TEXT")
                .HasMaxLength(Departamento.TAMANHO_MAXIMO_DESCRICAO)
                .IsRequired();

            #endregion
        }
    }
}
