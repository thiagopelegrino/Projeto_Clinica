using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //avaliação

namespace Projeto.Application.Models
{
    public class AtendimentoCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe a data do Atendimento.")]
        public DateTime DataAtendimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o local do Atenimento.")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Por favor, informe as observações do Atendimento.")]
        public string Obcervacoes { get; set; }
                
        [Required(ErrorMessage = "Por favor, informe o médico responsável pelo Atendimento.")]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Por favor, informe o paciente do Atendimento.")]
        public int IdMedico { get; set; }

    }
}
