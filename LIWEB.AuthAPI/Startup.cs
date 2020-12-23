using System;
using System.IO;
using System.Text.Json;
using LIWEB.AuthAPI.Models;
using Microsoft.OpenApi.Models;
using LIWEB.InjecaoDependencias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LIWEB.AuthAPI
{
    public class Startup
    {
        public Startup()
        {
            Configuration = BuildConfiguration();
        }

        public IConfigurationRoot BuildConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddEnvironmentVariables()
           .AddJsonFile("appsettings.json", false)
           .AddJsonFile($"appsettings.{env}.json", true);

            return config.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.RegistrarServicos(Configuration);

            services.AddCors();

           //ADD AUTH

            services.AddControllers();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Liweb", Version = "v1" });
                c.IncludeXmlComments("LIWEB.AuthAPI.xml");                
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "API LIWEB V1");
                });
            }

            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();

                    //if (exception != null) IMPLEMENTAR LOG DE ERROS
                    //    logger.LogError(500, "Mensagem {mesagem} trace: {result}", exception.Error.Message, exception.Error.StackTrace);

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json; charset=utf-8";

                    var erroServidorRespostaPadrao = new ErroServidorRespostaPadraoModel();

                    var jsonStringResposta = JsonSerializer.Serialize(erroServidorRespostaPadrao);

                    await context.Response.WriteAsync(jsonStringResposta);
                });
            });

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
