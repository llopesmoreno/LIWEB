using System;
using MediatR;
using AutoMapper;
using MongoDB.Driver;
using FluentValidation;
using LIWEB.Domain.Util;
using LIWEB.Domain.Entidades;
using LIWEB.Domain.Validadores;
using LIWEB.RepositorioMongoDb;
using LIWEB.Domain.Repositorios;
using MongoDB.Bson.Serialization;
using LIWEB.RepositorioMongoDb.Util;
using Microsoft.Extensions.Configuration;
using LIWEB.RepositorioMongoDb.Mapeamento;
using Microsoft.Extensions.DependencyInjection;

namespace LIWEB.InjecaoDependencias
{
    public static class InjetorDependenciaExtension
    {
        public static void RegistrarServicos(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var conexaoMongo = configuration["CONEXAO_MONGO"];
            var nomeMongoDataBase = configuration["DB_MONGO"];


            services.AddScoped<INotificador, Notificador>();
            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(Aplicacao.IMediatorMarcador));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            RegistrarRepositorios(services, conexaoMongo, nomeMongoDataBase);
            RegistrarValidadores(services);
            IncluirHttpClientSingleton(services);
        }

        private static void RegistrarRepositorios(IServiceCollection services, string conexaoMongo, string nomeBaseMongo)
        {
            var mongoCliente = new MongoClient(conexaoMongo).GetDatabase(nomeBaseMongo);
            services.AddSingleton(s => mongoCliente);

            services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();

            MongoDbBootstrapper.InicializarMapeamentos();
            BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer());
        }

        private static void RegistrarValidadores(IServiceCollection services)
        {
            services.AddScoped<IValidator<Usuario>, UsuarioValidador>();
        }

        private static void IncluirHttpClientSingleton(IServiceCollection services)
        {
            var clientHandler = new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            var httpClient = new System.Net.Http.HttpClient(clientHandler);

            services.AddSingleton(httpClient);
        }        
    }
}