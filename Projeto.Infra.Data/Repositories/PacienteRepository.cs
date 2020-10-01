using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class PacienteRepository : BaseRepository<PacienteEntity>, IPacienteRepository
    {
        //atributo
        private readonly DataContext context;

        //Construtor para insjeção de dependência
        public PacienteRepository(DataContext context)
            : base (context) //mandando para o contrutor da superclasse
        {
            this.context = context;
        }
    }
}
