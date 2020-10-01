using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class AtendimentoDomainService : BaseDomainService<AtendimentoEntity>, IAtendimentoDomainService
    {
        //atributo
        private readonly IAtendimentoRepository repository;

        //construtor para injeção de dependência (inicialização)
        public AtendimentoDomainService(IAtendimentoRepository repository)
            :base(repository) //construtor da superclasse
        {
            this.repository = repository;
        }
    }
}
