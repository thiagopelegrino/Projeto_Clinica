﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Projeto.Application.Contracts;
using Projeto.Application.Mappings;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;

namespace Projeto.Presentation
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region EntityFramework

            // configurando o uso do EntityFramwework na aplicação
            // injeção de dependencia na classe DataContext de forma a enviar o caminho da string de conexão do banco de dados
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer
                (Configuration.GetConnectionString("ProjetoFinal")));

            #endregion

            #region AutoMapper

            AutoMapperConfig.Register();

            #endregion

            #region Swagger

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Sistema de agendamento de consultas",
                        Description = "Projeto desenvolvido em DDD com API e EntityFramework",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Thiago Pelegrino",
                            Email = "thiagoquirinobr@hotmail.com.br"
                        }
                    });
                }
                );

            #endregion

            #region Injeção de dependência

            services.AddTransient<IAtendimentoApplicationService,AtendimentoApplicationService>();
            services.AddTransient<IMedicoApplicationService, MedicoApplicationService>();
            services.AddTransient<IPacienteApplicationService, PacienteApplicationService>();

            services.AddTransient<IAtendimentoDomainService, AtendimentoDomainService>();
            services.AddTransient<IMedicoDomainService, MedicoDomainService>();
            services.AddTransient<IPacienteDomainService, PacienteDomainService>();

            services.AddTransient<IAtendimentoRepository, AtendimentoRespository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Final");
            });

            #endregion

            app.UseMvc();
        }
    }
}
