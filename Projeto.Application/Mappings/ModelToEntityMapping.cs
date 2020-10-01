using AutoMapper;
using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Mappings
{
    public class ModelToEntityMapping : Profile
    {
        //criando o construtor
        public ModelToEntityMapping()
        {
            //entradas de dados (cadastro, edição, etc)
            CreateMap<AtendimentoCadastroModel, AtendimentoEntity>();
            CreateMap<MedicoCasdastroModel, MedicoEntity>();
            CreateMap<PacienteCadastroModel, PacienteEntity>();

            CreateMap<AtendimentoEdicaoModel, AtendimentoEntity>();
            CreateMap<MedicoEdicaoModel, MedicoEntity>();
            CreateMap<PacienteEdicaoModel, PacienteEntity>();
        }
    }
}
