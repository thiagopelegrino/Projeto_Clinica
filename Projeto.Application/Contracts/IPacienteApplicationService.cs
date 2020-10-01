using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Contracts
{
    public interface IPacienteApplicationService
    {
        void Cadastrar(PacienteCadastroModel model);
        void Atualizar(PacienteEdicaoModel model);
        void Excluir(int idPaciente);
        List<PacienteConsultaModel> Consultar();
        PacienteConsultaModel ObterPorId(int idPaciente);
    }
}
