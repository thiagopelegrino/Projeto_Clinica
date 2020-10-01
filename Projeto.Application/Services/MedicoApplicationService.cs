using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class MedicoApplicationService : IMedicoApplicationService
    {
        //atributo
        private readonly IMedicoDomainService domainService;

        //construtor para injeção de dependência (inicialização)
        public MedicoApplicationService(IMedicoDomainService domainService)
        {
            this.domainService = domainService;
        }
        public void Cadastrar(MedicoCasdastroModel model)
        {
            var medico = Mapper.Map<MedicoEntity>(model);
            domainService.Cadastrar(medico);
        }

        public void Atualizar(MedicoEdicaoModel model)
        {
            var medico = Mapper.Map<MedicoEntity>(model);
            domainService.Atualizar(medico);
        }
        public void Excluir(int idMedico)
        {
            var medico = domainService.ObterPorId(idMedico);
            domainService.Excluir(medico);
        }

        public List<MedicoConsultaModel> Consultar()
        {
            var lista = domainService.Consultar();
            return Mapper.Map<List<MedicoConsultaModel>>(lista);
        }       

        public MedicoConsultaModel ObterPorId(int idMedico)
        {
            var medico = domainService.ObterPorId(idMedico);
            return Mapper.Map<MedicoConsultaModel>(medico);
        }
    }
}
