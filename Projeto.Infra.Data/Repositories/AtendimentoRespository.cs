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
    public class AtendimentoRespository : BaseRepository<AtendimentoEntity>, IAtendimentoRepository
    {
        //atributo
        private readonly DataContext context;

        //Construtor para insjeção de dependência
        public AtendimentoRespository(DataContext context)
            : base (context) //mandando para o contrutor da superclasse
        {
            this.context = context;
        }
        public override List<AtendimentoEntity> GetAll()
        {
            return context.Atendimento
                    .Include(a => a.Medico) //INNER JOIN
                    .Include(a => a.Paciente)//INNER JOIN
                    .ToList();
        }
        public override List<AtendimentoEntity>
        GetAll(Func<AtendimentoEntity, bool> where)
        {
            return context.Atendimento
                    .Include(a => a.Medico) //INNER JOIN
                    .Include(a => a.Paciente)//INNER JOIN
                    .Where(where)
                    .ToList();
        }

        public override AtendimentoEntity Get(Func<AtendimentoEntity, bool> where)
        {
            return context.Atendimento
                    .Include(a => a.Medico) //INNER JOIN
                    .Include(a => a.Paciente) //INNER JOIN
                    .FirstOrDefault(where);
        }
        public override AtendimentoEntity GetById(int id)
        {
            return context.Atendimento
                    .Include(a => a.Medico) //INNER JOIN
                    .Include(a => a.Paciente) //INNER JOIN
                    .FirstOrDefault(c => c.IdAtendimento == id);
        }
    }
}
