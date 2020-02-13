using Microsoft.EntityFrameworkCore.Storage;
using Projeto.Domain.Contracts.Repositories;
using Projeto.InfraStructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.InfraStructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //atributos..
        private readonly DataContext context;
        private IDbContextTransaction transaction;

        //construtor para injeção de dependência
        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public IProductRepository ProductRepository => new ProductRepository(context);

        public IStockRepository StockRepository => new StockRepository(context);

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
