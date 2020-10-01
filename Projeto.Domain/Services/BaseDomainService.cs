using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        //atributo
        private readonly IBaseRepository<TEntity> repository;

        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public void Cadastrar(TEntity obj)
        {
            repository.Create(obj);
        }

        public void Atualizar(TEntity obj)
        {
            repository.Update(obj);
        }
        public void Excluir(TEntity obj)
        {
            repository.Delete(obj);
        }

        public List<TEntity> Consultar()
        {
            return repository.GetAll();
        }
        
        public TEntity ObterPorId(int id)
        {
            return repository.GetById(id);
        }
    }
}
