using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> FindAll();
        List<TEntity> FindAll(Func<TEntity, bool> where);

        TEntity FindById(int id);
        TEntity FindOne(Func<TEntity, bool> where);
    }
}
