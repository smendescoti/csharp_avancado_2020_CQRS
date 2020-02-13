using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Application;
using Projeto.Application.IoC;
using Projeto.InfraStructure.Data.Context;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation( //configurando o fluent validation
                    fluent => fluent.RegisterValidatorsFromAssemblies
                        (AppDomain.CurrentDomain.GetAssemblies()
                            .Where(p => !p.IsDynamic))
                );

            //adicionando o mapeamento da injeção de dependencia..
            DependencyResolver.Register(services, Configuration);

            //configurando injeção de dependência para o AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()
                                    .Where(p => !p.IsDynamic));

            //configurando o EntityFramework
            services.AddDbContext<DataContext>(
                    options => options.UseSqlServer
                    (Configuration.GetConnectionString("ProjetoCQRS"))
                );

            #region Swagger

            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new Info
                    {
                        Title = "API para Controle de Produtos",
                        Version = "v1",
                        Description = "Projeto CQRS"
                    });
                }
            );

            #endregion

            #region CORS

            services.AddCors(
                    c => c.AddPolicy("DefaultPolicy", //política de CORS
                        builder => 
                        {
                            //definir as permissões..
                            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                        })
                );

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
                }
                );

            #endregion

            #region CORS

            app.UseCors("DefaultPolicy");

            #endregion

            app.UseMvc();
        }
    }
}
