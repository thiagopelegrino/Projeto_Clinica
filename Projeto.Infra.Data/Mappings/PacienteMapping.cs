using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<PacienteEntity>
    {
        public void Configure(EntityTypeBuilder<PacienteEntity> builder)
        {
            //Nome da tabela no banco de dados
            builder.ToTable("Paciente");

            //Chave Primária
            builder.HasKey(p => p.IdPaciente);

            //Mapeando todos os campos da tabela
            builder.Property(p => p.IdPaciente)
                .HasColumnName("IdPaciente")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasMaxLength(30)
                .IsRequired();

        }
    }
}
