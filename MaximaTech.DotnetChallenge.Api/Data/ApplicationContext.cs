using MaximaTech.DotnetChallenge.Api.Data.Maps;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MaximaTech.DotnetChallenge.Api.Data
{
    /// <summary>
	/// Contexto padrão da aplicação.
	/// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
		/// Inicia uma nova instância do contexto.
		/// </summary>
		/// <param name="opcoes"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        #region DBSETS

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        #endregion

        /// <summary>
		/// Define os mapeamentos a serem aplicados durante a criação do modelo para o contexto.
		/// </summary>
		/// <param name="builder">O <see cref="ModelBuilder"/> para a construção do modelo.</param>
		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new DepartamentoMap());
        }
    }
}
