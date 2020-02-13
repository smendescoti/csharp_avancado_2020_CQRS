using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        //atributo..
        private readonly IBaseRepository<TEntity> repository;

        //construtor para injeção de dependência
        protected BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Cadastrar(TEntity entidade)
        {
            repository.Create(entidade);
        }

        public virtual void Atualizar(TEntity entidade)
        {
            repository.Update(entidade);
        }

        public virtual void Excluir(int id)
        {
            repository.Delete(repository.FindById(id));
        }

        public virtual List<TEntity> ConsultarTodos()
        {
            return repository.FindAll();
        }

        public virtual List<TEntity> ConsultarTodos(Func<TEntity, bool> filtro)
        {
            return repository.FindAll(filtro);
        }

        public virtual TEntity ConsultarPorId(int id)
        {
            return repository.FindById(id);
        }

        public virtual TEntity Obter(Func<TEntity, bool> filtro)
        {
            return repository.FindOne(filtro);
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }
    }
}
