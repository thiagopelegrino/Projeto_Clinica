using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class MedicoDomainService : BaseDomainService<MedicoEntity>, IMedicoDomainService
    {
        //atributo
        private readonly IMedicoRepository repository;

        //construtor para injeção de dependência (inicialização)
        public MedicoDomainService(IMedicoRepository repository)
            :base (repository) //construtor da superclasse
        {
            this.repository = repository;
        }
    }
}
