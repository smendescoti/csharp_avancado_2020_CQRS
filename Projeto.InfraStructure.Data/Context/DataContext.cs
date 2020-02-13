using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.InfraStructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.InfraStructure.Data.Context
{
    //REGRA 1) Herdar a classe DbContext
    public class DataContext : DbContext
    {
        //REGRA 2) Construtor para receber os parametros de acesso
        //ao banco de dados, como por exemplo, a connection string
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        //REGRA 3) Sobrescrita (OVERRIDE) do método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adicionar as classes de mapeamento..
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        //REGRA 4) Declarar uma propriedade DbSet para cada entidade
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
