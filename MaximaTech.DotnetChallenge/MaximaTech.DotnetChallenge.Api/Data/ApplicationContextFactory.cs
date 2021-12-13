using System;
using System.IO;
using MaximaTech.DotnetChallenge.Api.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MaximaTech.DotnetChallenge.Api.Data
{
    /// <summary>
    /// Fabrica de contexto para o EF Core.
    /// Utiliza a variável ASPNETCORE_ENVIRONMENT para definir qual arquivo de configuração usar.
    /// </summary>
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        /// <summary>
        /// Cria uma nova instância do contexto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="args">Argumentos para o DbContext.</param>
        /// <returns>Uma instância configurada de <see cref="ApplicationContext"/></returns>
        public ApplicationContext CreateDbContext(string[] args)
        {
            string stringDeConexao = ConnectionStringUtil.GetConnectionString("DbConnectionString");

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseNpgsql(stringDeConexao, opcoes =>
                opcoes.MigrationsAssembly("MaximaTech.DotnetChallenge.Api"));

            var context = new ApplicationContext(builder.Options);
            return context;
        }
    }
}
