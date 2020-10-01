using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //validação

namespace Projeto.Application.Models
{
    public class MedicoCasdastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do Médico.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CRM do Médico.")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Por favor, informe a especialização do Médico.")]
        public string Especializacao { get; set; }
    }
}
