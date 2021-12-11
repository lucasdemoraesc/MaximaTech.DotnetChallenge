using System;
using MaximaTech.DotnetChallenge.Api.Data;
using MaximaTech.DotnetChallenge.Api.Data.Repositories;
using MaximaTech.DotnetChallenge.Api.Data.Repositories.Implementations;
using MaximaTech.DotnetChallenge.Api.Data.Repositories.Interfaces;
using MaximaTech.DotnetChallenge.Api.Services.Implementations;
using MaximaTech.DotnetChallenge.Api.Services.Interfaces;
using MaximaTech.DotnetChallenge.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaximaTech.DotnetChallenge.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesResolution(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            return services;
        }

        public static IServiceCollection AddRepositoriesResolution(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            return services;
        }

        public static IServiceCollection AddDbContextResolution(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
