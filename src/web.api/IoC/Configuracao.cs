namespace PrimeControl.WebAPI.IoC
{
    using System.Data;
    using System.Web.Http;
    using PrimeControl.Core.Repositorio;
    using PrimeControl.Core.Repositorio.Impl;
    using PrimeControl.Core.Services;
    using PrimeControl.Core.Services.Impl;
    using PrimeControl.WebAPI.ServicoAplicacao;
    using PrimeControl.WebAPI.ServicoAplicacao.Impl;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Npgsql;

    public static class Configuracao
    {
        public static void InjetarDependenciasCore(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IDbConnection, NpgsqlConnection>(provider => new NpgsqlConnection(configuration.GetConnectionString("PostgreSql")));
            // TODO você pode utilizar também o SQL Server comentando descomentando a linha abaixo!
            services.AddScoped<IDbConnection, SqlConnection>(provider => new SqlConnection(configuration.GetConnectionString("SqlServer")));
            services.AddScoped<IServicoAplicacaoClientePessoaFisica, ServicoAplicacaoClientePessoaFisica>();
            services.AddScoped<IServicoDominioClientePessoaFisica, ServicoDominioClientePessoaFisica>();
            services.AddScoped<IRepositorioClientePessoaFisica, RepositorioClientePessoaFisica>();
            services.AddScoped<IServicoAplicacaoClientePessoaJuridica, ServicoAplicacaoClientePessoaJuridica>();
            services.AddScoped<IServicoDominioClientePessoaJuridica, ServicoDominioClientePessoaJuridica>();
            services.AddScoped<IRepositorioClientePessoaJuridica, RepositorioClientePessoaJuridica>();
        }

    }
}