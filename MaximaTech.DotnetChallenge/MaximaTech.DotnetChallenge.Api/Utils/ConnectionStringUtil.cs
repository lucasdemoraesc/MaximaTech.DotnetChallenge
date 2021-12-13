using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MaximaTech.DotnetChallenge.Api.Utils
{
    public class ConnectionStringUtil
    {
        public static string GetConnectionString(string connectionString)
        {
            string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            string stringDeConexao = configuracao.GetConnectionString(connectionString);
            return stringDeConexao;
        }
    }
}
