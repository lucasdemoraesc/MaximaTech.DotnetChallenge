using System;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaximaTech.DotnetChallenge.Api.Data.Maps
{
    public abstract class BaseMap<TModel> where TModel : BaseModel
    {
        public void ConfigureBaseModel(EntityTypeBuilder<TModel> builder)
        {
            #region ID

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID");

            #endregion

            #region CODIGO

            builder.Property(x => x.Codigo)
                .HasColumnName("CODIGO")
                .HasColumnType("INT")
                .IsRequired();

            builder.HasIndex(x => x.Codigo)
                .HasDatabaseName("IDX_CODIGO" + typeof(TModel).Name.ToUpper())
                 .IsUnique();

            #endregion

            #region STATUS

            builder.Property(x => x.Status)
                    .HasColumnName("STATUS")
                    .IsRequired();

            #endregion
        }
    }
}
