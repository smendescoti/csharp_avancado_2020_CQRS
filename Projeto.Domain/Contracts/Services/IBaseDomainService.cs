using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity> : IDisposable
        where TEntity : class
    {
        void Cadastrar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Excluir(int id);

        List<TEntity> ConsultarTodos();
        List<TEntity> ConsultarTodos(Func<TEntity, bool> filtro);

        TEntity ConsultarPorId(int id);
        TEntity Obter(Func<TEntity, bool> filtro);
    }
}
