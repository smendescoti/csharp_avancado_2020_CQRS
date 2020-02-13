using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.InfraStructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.InfraStructure.Data.Repositories
{
    public class StockRepository
        : BaseRepository<Stock>, IStockRepository
    {
        //atributo..
        private readonly DataContext context;

        //construtor
        public StockRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }

        public override List<Stock> FindAll()
        {
            return context.Stocks
                    .Include(s => s.Products)
                    .ToList();
        }

        public override List<Stock> FindAll(Func<Stock, bool> where)
        {
            return context.Stocks
                    .Include(s => s.Products)
                    .Where(where)
                    .ToList();
        }

        public override Stock FindById(int id)
        {
            return context.Stocks
                    .Include(s => s.Products)
                    .FirstOrDefault(s => s.Id == id);
        }

        public override Stock FindOne(Func<Stock, bool> where)
        {
            return context.Stocks
                    .Include(s => s.Products)
                    .FirstOrDefault(where);
        }
    }
}
