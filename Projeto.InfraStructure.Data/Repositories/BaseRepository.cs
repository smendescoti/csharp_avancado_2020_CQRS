using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.InfraStructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.InfraStructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        //atributo
        private readonly DataContext context;

        //construtor para inicializar o atributo (injeção de dependencia)
        protected BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public virtual void Create(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public virtual List<TEntity> FindAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>().Where(where).ToList();
        }

        public virtual TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual TEntity FindOne(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>().FirstOrDefault(where);
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }
    }
}
