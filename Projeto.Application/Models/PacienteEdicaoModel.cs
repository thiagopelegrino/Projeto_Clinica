using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //validação

namespace Projeto.Application.Models
{
    public class PacienteEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o ID do Paciente.")]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do Paciente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CPF do Paciente.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do Paciente.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone do Paciente.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor, informe o E-mail do Paciente.")]
        public string Email { get; set; }
    }
}
