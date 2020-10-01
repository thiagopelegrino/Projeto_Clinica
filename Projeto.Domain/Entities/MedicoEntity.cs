using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Entities
{
    public class MedicoEntity
    {
        public int IdMedico { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Especializacao { get; set; }

        #region Relacionamentos
        public List<AtendimentoEntity> Atendimento { get; set; }
        #endregion
    }
}
