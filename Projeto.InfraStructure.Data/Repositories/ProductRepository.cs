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
    public class ProductRepository
        : BaseRepository<Product>, IProductRepository
    {
        //atributo
        private readonly DataContext context;

        //construtor
        public ProductRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }

        public override List<Product> FindAll()
        {
            return context.Products
                    .Include(p => p.Stock)
                    .ToList();
        }

        public override List<Product> FindAll(Func<Product, bool> where)
        {
            return context.Products
                    .Include(p => p.Stock)
                    .Where(where)
                    .ToList();
        }

        public override Product FindById(int id)
        {
            return context.Products
                    .Include(p => p.Stock)
                    .FirstOrDefault(p => p.Id == id);
        }

        public override Product FindOne(Func<Product, bool> where)
        {
            return context.Products
                    .Include(p => p.Stock)
                    .FirstOrDefault(where);
        }
    }
}
