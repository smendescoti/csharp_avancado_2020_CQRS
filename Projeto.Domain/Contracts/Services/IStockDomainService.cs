using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IStockDomainService
        : IBaseDomainService<Stock>
    {
        void Cadastrar(Stock stock, List<Product> products);
    }
}
