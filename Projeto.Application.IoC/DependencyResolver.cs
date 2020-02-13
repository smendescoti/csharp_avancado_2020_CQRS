using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.InfraStructure.Data.Repositories;
using System;

namespace Projeto.Application.IoC
{
    public class DependencyResolver
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {   
            #region Application

            #endregion

            #region Domain

            services.AddTransient<IStockDomainService, StockDomainService>();
            services.AddTransient<IProductDomainService, ProductDomainService>();
            
            #endregion

            #region InfraStructure

            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion
        }
    }
}
