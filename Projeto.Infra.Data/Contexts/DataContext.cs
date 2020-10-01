using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    //regra 1: Herdando dbcontext
    public class DataContext : DbContext
    {
        //Regra 2: Construtor para receber a connectionstring e envia-la
        //para o construtor da superclasse -> DbContext (Injeção de dependência)
        public DataContext(DbContextOptions<DataContext> options)
            : base (options) //construtor superclasse  (Dbcontext)
        {

        }

        //Regra 3: Sobrescrever o método OnModelCreating (OVERRIDE)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration (new AtendimentoMapping());
            modelBuilder.ApplyConfiguration (new PacienteMapping());
            modelBuilder.ApplyConfiguration(new MedicoMapping());
        }
        //Regra 4: Declarar um DbSet para cada classe de entidade (LAMBDA)
        public DbSet<AtendimentoEntity> Atendimento { get; set; }
        public DbSet<PacienteEntity> Paciente { get; set; }
        public DbSet<MedicoEntity> Medico { get; set; }
    }
}
