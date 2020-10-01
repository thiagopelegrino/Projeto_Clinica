using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class AtendimentoMapping : IEntityTypeConfiguration<AtendimentoEntity>
    {
        public void Configure(EntityTypeBuilder<AtendimentoEntity> builder)
        {
            //Nome da tabela no banco de dados
            builder.ToTable("Atendimento");

            //Chave Primária
            builder.HasKey(a => a.IdAtendimento);

            //Mapeando todos os campos da tabela
            builder.Property(p => p.IdAtendimento)
                .HasColumnName("IdAtendimento")
                .IsRequired();

            builder.Property(a => a.DataAtendimento)
               .HasColumnName("DataAtendimento")
               .HasColumnType("date")
               .IsRequired();

            builder.Property(a => a.Local)
                .HasColumnName("Local")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Obcervacoes)
                .HasColumnName("Observacoes")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(a => a.IdMedico)
                .HasColumnName("IdMedico")
                .IsRequired();

            builder.Property(a => a.IdPaciente)
                .HasColumnName("IdPaciente")
                .IsRequired();

            #region Relacionamentos
            builder.HasOne(a => a.Paciente)
                .WithMany(p => p.Atendimento)
                .HasForeignKey(a => a.IdPaciente);

            builder.HasOne(a => a.Medico)
                .WithMany(m => m.Atendimento)
                .HasForeignKey(a => a.IdMedico);

            #endregion

        }
    }
}
