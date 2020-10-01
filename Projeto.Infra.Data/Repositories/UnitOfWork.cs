using Microsoft.EntityFrameworkCore.Storage;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //Atributo
        private readonly DataContext context;
        private IDbContextTransaction transaction;

        //Gerando o construtor para injeção de dependência
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

        public IMedicoRepository MedicoRepository
        {
            get { return new MedicoRepository(context); }
        }

        public IAtendimentoRepository AtendimentoRepository
        {
            get { return new AtendimentoRespository(context); }
        }

        public IPacienteRepository PacienteRepository
        {
            get { return new PacienteRepository(context); }
        }
    }
}
