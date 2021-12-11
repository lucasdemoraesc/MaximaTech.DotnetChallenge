using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaximaTech.DotnetChallenge.Api.Data.Maps
{
    public class ProdutoMap : BaseMap<Produto>, IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");

            ConfigureBaseModel(builder);

            #region DESCRICAO

            builder.Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasColumnType("TEXT")
                .HasMaxLength(Departamento.TAMANHO_MAXIMO_DESCRICAO)
                .IsRequired();

            #endregion

            #region DEPARTAMENTO

            builder.HasOne(x => x.Departamento)
                .WithMany()
                .HasForeignKey("IDDEPARTAMENTO")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(x => x.Departamento)
                .AutoInclude();

            #endregion

            #region PRECO

            builder.Property(x => x.Preco)
                .HasColumnName("PRECO")
                .IsRequired();

            #endregion
        }

    }
}
