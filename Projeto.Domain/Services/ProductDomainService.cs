using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class ProductDomainService 
        : BaseDomainService<Product>, IProductDomainService
    {
        //atributo
        private readonly IUnitOfWork unitOfWork;

        //construtor para injeção de dependência
        public ProductDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.ProductRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
