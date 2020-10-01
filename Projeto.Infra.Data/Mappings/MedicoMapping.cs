using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<MedicoEntity>
    {
        public void Configure(EntityTypeBuilder<MedicoEntity> builder)
        {
            //Nome da tabela no Banco de dados
            builder.ToTable("Medico");

            //chave primária
            builder.HasKey(m => m.IdMedico);

            //Mapeando todos os campos da tabela
            builder.Property(m => m.IdMedico)
                .HasColumnName("IdMedico");

            builder.Property(m => m.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.CRM)
                .HasColumnName("CRM")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(m => m.Especializacao)
                .HasColumnName("Especializacao")
                .HasMaxLength(30)
                 .IsRequired();

        }
    }
}
