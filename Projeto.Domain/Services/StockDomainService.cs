using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class StockDomainService
        : BaseDomainService<Stock>, IStockDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public StockDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.StockRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Cadastrar(Stock stock, List<Product> products)
        {
            if (products != null && products.Count > 0)
            {
                try
                {
                    unitOfWork.BeginTransaction();

                    unitOfWork.StockRepository.Create(stock);

                    foreach (var product in products)
                    {
                        product.StockId = stock.Id; //foreign key..
                        unitOfWork.ProductRepository.Create(product);
                    }

                    unitOfWork.Commit();
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback();
                    throw new Exception(e.Message);
                }
            }
            else
            {
                base.Cadastrar(stock);
            }            
        }
    }
}
